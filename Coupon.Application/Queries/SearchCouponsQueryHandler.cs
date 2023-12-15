using AutoMapper;
using Coupon.Application.Interfaces;
using Coupon.Domain.Models;
using Coupon.Infrastructure.Interfaces;
using Coupon.Infrastructure.Entities;
using Microsoft.Extensions.Logging;

namespace Coupon.Application.Queries
{
    public class SearchCouponsQueryHandler : IQueryHandler<CouponSearch, Task<FilteredCoupon>>
    {
        #region References
        private readonly ILogger<SearchCouponsQueryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly ICouponRepository _couponOperation;
        #endregion

        #region Public Members
        public SearchCouponsQueryHandler(
            ILogger<SearchCouponsQueryHandler> logger,
            IMapper mapper,
            ICouponRepository couponOperation)
        {
            _logger = logger;
            _mapper = mapper;
            _couponOperation = couponOperation;
        }

        /// <summary>
        /// Gets filtered Coupons data based on search 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<FilteredCoupon> ExecuteQuery(
            CouponSearch request)
        {
            _logger.LogInformation("SearchCouponsQueryHandler triggered to retrieve recommended coupons");
            
            var coupons = await _couponOperation.GetCoupons(request);
            var brands = coupons.Where(x => x.BrandName != null)
                .GroupBy(x => x.BrandName).Select(g => new CouponBrand
                {
                    Name = g.Key,
                    Count = g.Count()
                }).ToList();
            var categories = coupons
                .Where(x => x.RewardCatagoryName != null)
                .GroupBy(x => x.RewardCatagoryName).Select(g =>
                new CouponCategory
                {
                    Name = g.Key,
                    Count = g.Count()
                }).ToList();


            return new FilteredCoupon()
            {
                Coupons = _mapper.Map<List<Coupons>, List<BaseCoupon>>(coupons.ToList()),
                Brands = brands,
                Category = categories,
                PaginationInfo = new CouponPagination()
                {
                    StartRecord = request.PageIndex,
                    TotalRecords = coupons.Count(),
                    ExpectedRecordsPerPage = coupons.Count(),
                    TotalRecordsPerPage = coupons.Count()
                }
            };
        }

        #endregion

    }
}
