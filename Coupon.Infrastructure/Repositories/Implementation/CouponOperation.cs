using Coupon.Infrastructure.Repositories.Database;
using Coupon.Infrastructure.Repositories.Database.Entities;
using Coupon.Infrastructure.Repositories.Interfaces;

namespace Coupon.Infrastructure.Repositories.Implementation
{
    public class CouponOperation : ICouponOperation
    {
        private readonly CouponDbContext _dbContext;

        public CouponOperation(CouponDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<CouponInfo> GetCoupons()
        {
            return _dbContext.Coupons.AsEnumerable();
        }
    }
}
