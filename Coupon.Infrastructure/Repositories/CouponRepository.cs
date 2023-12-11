using Coupon.Domain.Models;
using Coupon.Infrastructure.Interfaces;
using Coupon.Infrastructure.Entities;
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

        public IEnumerable<CouponInfo> GetCoupons(RecommendedCoupon filters)
        {
            // Step 1: Create CouponInfo instances
            var coupons = _dbContext.UserCoupons
                .Where(w => w.IsClipped == 0)
                .Join(
                    _dbContext.Coupons,
                    w => w.OfferId,
                    c => c.OfferId,
                    (w, c) => new CouponInfo
                    { 
                        OfferId = c.OfferId,
                        OfferSrc = c.OfferSrc,
                        ActivationDt = c.ActivationDt,
                        OfferAssnCd=c.OfferAssnCd,
                        BrandName=c.BrandName,
                        CompanyName=c.CompanyName,
                        OfferImg1=c.OfferImg1,
                        OfferImg2 = c.OfferImg2,
                        IsAutoActivated =c.IsAutoActivated,
                        MinBasketValue =c.MinBasketValue,
                        MinQty=c.MinQty,
                        MinQtyDesc=c.MinQtyDesc,
                        MinTripCount=c.MinTripCount,    
                        ProdtOffrActDt=c.ProdtOffrActDt,
                        OfferCd=c.OfferCd,  
                        OfferDesc=c.OfferDesc,  
                        OfferDisclaimer=c.OfferDisclaimer,  
                        ProdtOffrExpiryDt=c.ProdtOffrExpiryDt,
                        OfferFeaturedTxt    =c.OfferFeaturedTxt,    
                        OfferFinePrt=c.OfferFinePrt,    
                        OfferGs1=c.OfferGs1,
                        OfferSum=c.OfferSum,    
                        OfferType=c.OfferType,
                        RedemptionFreq=c.RedemptionFreq,    
                        RedemptionLimitQty=c.RedemptionLimitQty,
                        RewardCatagoryName=c.RewardCatagoryName,    
                        RewardOfferVal=c.RewardOfferVal,
                        TgtType=c.TgtType,  
                        TimesShopQty=c.TimesShopQty,
                        Visible=c.Visible,
                        OfferToken=c.OfferToken,
                        SortNumber = w.SortNumber
                    })
                .Where(w=>w.ProdtOffrExpiryDt > DateTime.Now)
                .OrderBy(w=>w.SortNumber)
                .Take(filters.NumPageRecords)
                .ToList();

            // Step 2: Update CouponInfo instances with LinkedUpcsCount
           
            var couponIds = coupons.Select(c => c.OfferId).ToList();
            
            var upcCounts = _dbContext.CouponUpcXrTs
                .Where(cu => couponIds.Contains(cu.OfferId))
                .GroupBy(cu => cu.OfferId)
                .Select(g => new { OfferId = g.Key, UpcCount = g.Count() }).ToList();

            foreach (var coupon in coupons)
            {
                coupon.UpcCount = upcCounts.Where(c => c.OfferId == coupon.OfferId).Select(x => x.UpcCount).FirstOrDefault();                       
            }

            return coupons;

        }

        //private static Expression<Func<CouponInfo, bool>> GetCouponsExpression(
        //    RecommendedCoupon filters)
        //{
        //    //starting with 1==1 to create a base expression
        //    BinaryExpression filterExp = Expression.Equal(Expression.Constant(1), Expression.Constant(1));
          
        //    return (Expression<Func<CouponInfo, bool>>)Expression.Lambda(filterExp);
        //}

        public IEnumerable<CouponInfo> GetCoupons(CouponSearch filters)
        {
            var exp = GetFiltersExpression(filters);
            var coupons = _dbContext.UserCoupons
                .Where(w => w.IsClipped == 0)
                .Join(
                    _dbContext.Coupons,
                    w => w.OfferId,
                    c => c.OfferId,
                    (w, c) => new CouponInfo
                    {
                        OfferId = c.OfferId,
                        OfferSrc = c.OfferSrc,
                        ActivationDt = c.ActivationDt,
                        OfferAssnCd = c.OfferAssnCd,
                        BrandName = c.BrandName,
                        CompanyName = c.CompanyName,
                        OfferImg1 = c.OfferImg1,
                        OfferImg2 = c.OfferImg2,
                        IsAutoActivated = c.IsAutoActivated,
                        MinBasketValue = c.MinBasketValue,
                        MinQty = c.MinQty,
                        MinQtyDesc = c.MinQtyDesc,
                        MinTripCount = c.MinTripCount,
                        ProdtOffrActDt = c.ProdtOffrActDt,
                        OfferCd = c.OfferCd,
                        OfferDesc = c.OfferDesc,
                        OfferDisclaimer = c.OfferDisclaimer,
                        ProdtOffrExpiryDt = c.ProdtOffrExpiryDt,
                        OfferFeaturedTxt = c.OfferFeaturedTxt,
                        OfferFinePrt = c.OfferFinePrt,
                        OfferGs1 = c.OfferGs1,
                        OfferSum = c.OfferSum,
                        OfferType = c.OfferType,
                        RedemptionFreq = c.RedemptionFreq,
                        RedemptionLimitQty = c.RedemptionLimitQty,
                        RewardCatagoryName = c.RewardCatagoryName,
                        RewardOfferVal = c.RewardOfferVal,
                        TgtType = c.TgtType,
                        TimesShopQty = c.TimesShopQty,
                        Visible = c.Visible,
                        OfferToken = c.OfferToken,
                        SortNumber = w.SortNumber
                    }).Where(exp)
                .OrderBy(w => w.SortNumber)
                .Take(filters.NumPageRecords)
                .ToList();

            // Step 2: Update CouponInfo instances with LinkedUpcsCount

            var couponIds = coupons.Select(c => c.OfferId).ToList();
           
            var upcCounts = _dbContext.CouponUpcXrTs
                .Where(cu => couponIds.Contains(cu.OfferId))
                .GroupBy(cu => cu.OfferId)
                .Select(g => new { OfferId = g.Key, UpcCount = g.Count() }).ToList();

            foreach (var coupon in coupons)
            {
                coupon.UpcCount = upcCounts.Where(c => c.OfferId == coupon.OfferId).Select(x => x.UpcCount).FirstOrDefault();
            }

            return coupons;
            //var exp = GetFiltersExpression(filters);
            //return _dbContext.Coupons
            //    .Where(exp)
            //    .AsEnumerable();
        }

        private static Expression<Func<CouponInfo, bool>> GetFiltersExpression(
            CouponSearch filters)
        {
            //this is the arguement to our lambda expression
             var paramater = Expression.Parameter(typeof(CouponInfo), "x");

           // starting with 1 == 1 to create a base expression
            BinaryExpression filterExp = Expression.Equal(Expression.Constant(1), Expression.Constant(1));
            //Expression<Func<CouponInfo, bool>> filterExp = x => x.IsClipped == 0;// && x.OfferExpiryDt > DateTime.Now;
            //Expression<Func<CouponInfo, bool>> filterExp = f => f.OfferExpiryDt > DateTime.Now;

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

            //Expression<Func<CouponInfo, bool>> filterExp = f => f.OfferExpiryDt > DateTime.Now;

            //if (filters.Categories != null && filters.Categories.Any())
            //{
            //    Expression<Func<CouponInfo, bool>> exp = x => x.RewardCatagoryName != null && filters.Categories.Contains(x.RewardCatagoryName);
            //    filterExp = Expression.Lambda<Func<CouponInfo, bool>>(Expression.AndAlso(filterExp, exp.Body),filterExp.Parameters);
            //}

            //if (filters.Brands != null && filters.Brands.Any())
            //{
            //    Expression<Func<CouponInfo, bool>> exp = x => x.BrandName != null && filters.Brands.Contains(x.BrandName);
            //    filterExp = Expression.Lambda<Func<CouponInfo, bool>>(Expression.AndAlso(filterExp, exp.Body), filterExp.Parameters);
            //}

            //if (!string.IsNullOrWhiteSpace(filters.Description))
            //{
            //    Expression<Func<CouponInfo, bool>> exp = x => x.OfferDesc != null && x.OfferDesc.Contains(filters.Description);
            //    filterExp = Expression.Lambda<Func<CouponInfo, bool>>(Expression.AndAlso(filterExp, exp.Body), filterExp.Parameters);
            //}

            //return (Expression<Func<CouponInfo, bool>>)Expression.Lambda(filterExp);

        }

    }
}
