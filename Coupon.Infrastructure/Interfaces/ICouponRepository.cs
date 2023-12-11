using Coupon.Domain.Models;
using Coupon.Infrastructure.Entities;

namespace Coupon.Infrastructure.Interfaces
{
    public interface ICouponRepository
    {
        IEnumerable<CouponInfo> GetCoupons();

        IEnumerable<CouponInfo> GetCoupons(RecommendedCoupon filters);

        IEnumerable<CouponInfo> GetCoupons(CouponSearch filters);
    }
}
