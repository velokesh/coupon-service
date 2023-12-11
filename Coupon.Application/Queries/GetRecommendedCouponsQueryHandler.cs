#region References
using AutoMapper;
using Coupon.Application.Interfaces;
using Coupon.Domain.Models;
using Coupon.Infrastructure.Interfaces;
using Coupon.Infrastructure.Entities;
using Microsoft.Extensions.Logging;
#endregion

namespace Coupon.Application.Queries
{
    public class GetRecommendedCouponsQueryHandler : IQueryHandler<RecommendedCoupon, FilteredCoupon>
    {
        #region References
        private readonly ILogger<GetRecommendedCouponsQueryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly ICouponRepository _couponOperation;
        #endregion

        #region Public Members
        public GetRecommendedCouponsQueryHandler(
            ILogger<GetRecommendedCouponsQueryHandler> logger,
            IMapper mapper,
            ICouponRepository couponOperation)
        {
            _logger = logger;
            _mapper = mapper;
            _couponOperation = couponOperation;
        }

        /// <summary>
        /// Gets Recommended Coupons
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public FilteredCoupon ExecuteQuery(
            RecommendedCoupon request)
        {
            _logger.LogInformation("GetRecommendedCouponsQueryHandler triggered to retrieve recommended coupons");

            var coupons = _couponOperation.GetCoupons(request);

            return new FilteredCoupon()
            {
                Coupons = _mapper.Map<List<CouponInfo>, List<BaseCoupon>>(coupons.ToList()),
                Brands = new List<CouponBrand>(),
                Category = new List<CouponCategory>(),
                PaginationInfo = new CouponPagination() {
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
