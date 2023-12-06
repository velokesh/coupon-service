using Coupon.Domain.Models;
using Coupon.Infrastructure.Interfaces;
using Coupon.Infrastructure.Repositories.Database.Entities;
using System.Linq.Expressions;

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

        public IEnumerable<CouponInfo> GetCoupons(CouponSearch filters)
        {
            var exp = GetFiltersExpression(filters);
            return _dbContext.Coupons
                .Where(exp)
                .AsEnumerable();
        }

        private static Expression<Func<CouponInfo, bool>> GetFiltersExpression(
            CouponSearch filters)
        {
            //this is the arguement to our lambda expression
            var paramater = Expression.Parameter(typeof(CouponInfo), "x");

            //starting with 1==1 to create a base expression
            BinaryExpression filterExp = Expression.Equal(Expression.Constant(1), Expression.Constant(1));

            if (filters.Categories != null && filters.Categories.Any())
            {
                Expression<Func<CouponInfo, bool>> exp = x => x.RewardCatagoryName != null && filters.Categories.Contains(x.RewardCatagoryName);
                filterExp = Expression.AndAlso(filterExp, Expression.Invoke(exp, paramater));
            }

            if (filters.Brands != null && filters.Brands.Any())
            {
                Expression<Func<CouponInfo, bool>> exp = x => x.BrandName != null && filters.Brands.Contains(x.BrandName);
                filterExp = Expression.AndAlso(filterExp, Expression.Invoke(exp, paramater));
            }

            if (!string.IsNullOrWhiteSpace(filters.Description))
            {
                Expression<Func<CouponInfo, bool>> exp = x => x.OfferDesc != null && x.OfferDesc.Contains(filters.Description);
                filterExp = Expression.AndAlso(filterExp, Expression.Invoke(exp, paramater));
            }

            return (Expression<Func<CouponInfo, bool>>)Expression.Lambda(filterExp, paramater);
        }

    }
}
