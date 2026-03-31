using Discount.Application.Dtos;
using Discount.Application.Mappers;
using Discount.Application.Queries;
using Discount.Core.Repositories;
using MediatR;

namespace Discount.Application.Handlers
{
    public class GetDiscountHandler : IRequestHandler<GetDiscountQuery, CouponDto>
    {
        private readonly IDiscountRepository _discountRepository;

        public GetDiscountHandler(IDiscountRepository discountRepository)
        {
            _discountRepository = discountRepository;
        }
        public async Task<CouponDto> Handle(GetDiscountQuery request, CancellationToken cancellationToken)
        {
            // Validation input
            if (string.IsNullOrWhiteSpace(request.productName))
            {
                var validationErrors = new Dictionary<string, string>()
                {
                    {"ProductName","Product name must not be empty." }
                };
            }
            // Fetch from repo
            var coupon = await _discountRepository.GetDiscount(request.productName);
            if (coupon == null) 
            {
                throw new Exception($"Discount for the Product Name = {request.productName} not found.");  
            }
            // Mapping
            return coupon.ToDto();

        }
    }
}
