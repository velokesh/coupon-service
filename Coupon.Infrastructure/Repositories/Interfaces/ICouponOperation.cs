using Coupon.Infrastructure.Repositories.DTO;

namespace Coupon.Infrastructure.Repositories.Interfaces
{
    public interface ICouponOperation
    {
        Task<IEnumerable<DTO.Coupon>> GetCoupons();
    }
}
