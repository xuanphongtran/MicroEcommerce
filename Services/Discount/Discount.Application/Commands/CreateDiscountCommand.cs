using Discount.Application.Dtos;
using MediatR;

namespace Discount.Application.Commands
{
    public record CreateDiscountCommand(string ProductName, string Description, int Amount) : IRequest<CouponDto>;
}
