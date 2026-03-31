using Discount.Application.Dtos;
using MediatR;

namespace Discount.Application.Queries
{
    public record GetDiscountQuery(string productName) : IRequest<CouponDto>;
    
}
