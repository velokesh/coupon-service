using Coupon.Infrastructure.Interfaces;
using Coupon.Infrastructure.Repositories.Database.Entities;

namespace Coupon.Infrastructure.Repositories
{
    public class CouponRepository : ICouponRepository
    {
        private readonly CouponDbContext _dbContext;

        public CouponRepository(CouponDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<CouponInfo> GetCoupons()
        {
            return _dbContext.Coupons.AsEnumerable();
        }
    }
}
