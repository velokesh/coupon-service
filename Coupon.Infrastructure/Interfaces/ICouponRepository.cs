using Coupon.Infrastructure.Repositories.Database.Entities;

namespace Coupon.Infrastructure.Interfaces
{
    public interface ICouponRepository
    {
        IEnumerable<CouponInfo> GetCoupons();
    }
}
