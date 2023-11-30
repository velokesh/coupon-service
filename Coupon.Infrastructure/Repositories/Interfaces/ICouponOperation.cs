using Coupon.Infrastructure.Repositories.Database.Entities;

namespace Coupon.Infrastructure.Repositories.Interfaces
{
    public interface ICouponOperation
    {
        IEnumerable<CouponInfo> GetCoupons();
    }
}
