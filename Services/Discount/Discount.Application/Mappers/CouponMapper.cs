using Discount.Application.Commands;
using Discount.Application.Dtos;
using Discount.Core.Entities;

namespace Discount.Application.Mappers
{
    public static class CouponMapper
    {
        public static CouponDto ToDto(this Coupon coupon)
        {
            return new CouponDto(coupon.Id, coupon.ProductName, coupon.Amount, coupon.Description);
        }
        public static Coupon ToEntity(this CreateDiscountCommand command)
        {
            return new Coupon
            {
                ProductName = command.ProductName,
                Description = command.Description,
                Amount = command.Amount
            };
        }
        public static Coupon ToEntity(this UpdateDiscountCommand command)
        {
            return new Coupon
            {
                ProductName = command.ProductName,
                Description = command.Description,
                Amount = command.Amount
            };
        }
    }
}
