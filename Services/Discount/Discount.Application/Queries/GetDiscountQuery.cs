using Discount.Application.Dtos;
using MediatR;

namespace Discount.Application.Queries
{
    public record GetDiscountQuery(string ProductName) : IRequest<CouponDto>;
    
}
