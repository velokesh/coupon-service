using Coupon.Domain.Models;
using Coupon.Infrastructure.Entities;

namespace Coupon.Infrastructure.Interfaces
{
    public interface ICouponRepository
    {
        Task<IEnumerable<Coupons>> GetCoupons(RecommendedCoupon filters);

        Task<IEnumerable<Coupons>> GetCoupons(CouponSearch filters);
    }
}
