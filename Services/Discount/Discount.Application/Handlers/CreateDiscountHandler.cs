using Discount.Application.Commands;
using Discount.Application.Dtos;
using Discount.Application.Extensions;
using Discount.Application.Mappers;
using Discount.Core.Repositories;
using Grpc.Core;
using MediatR;

namespace Discount.Application.Handlers
{
    public class CreateDiscountHandler : IRequestHandler<CreateDiscountCommand, CouponDto>
    {
        private readonly IDiscountRepository _discountRepository;

        public CreateDiscountHandler(IDiscountRepository discountRepository)
        {
            _discountRepository = discountRepository;
        }
        public async Task<CouponDto> Handle(CreateDiscountCommand request, CancellationToken cancellationToken)
        {
            // Validation input
            var validationErrors = new Dictionary<string, string>();
            if (string.IsNullOrEmpty(request.ProductName))
                validationErrors["ProductName"] = "Product Name must not be empty.";
            if (string.IsNullOrEmpty(request.Description))
                validationErrors["Description"] = "Product Description must not be empty.";
            if(request.Amount <= 0)
                validationErrors["Amount"] = "Amount must be greater than zero.";
            if(validationErrors.Any())
                throw GrpcErrorHelper.CreateValidationException(validationErrors);

            // Convert to entity
            var coupon = request.ToEntity();

            // Save to database
            var createdCoupon = await _discountRepository.CreateDiscount(coupon);
            if (!createdCoupon)
            {
                throw new RpcException(new Status(StatusCode.Internal, $"Could not create discount for product: {request.ProductName}"));
            }    
            // Return DTO
            return coupon.ToDto();
        }
    }
}
