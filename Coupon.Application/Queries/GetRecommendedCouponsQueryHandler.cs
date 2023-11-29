#region References
using Coupon.Application.Interfaces;
using Coupon.Domain.Models;
using Coupon.Infrastructure.Repositories.Interaces;
using Microsoft.Extensions.Logging;
#endregion

namespace Coupon.Application.Queries
{
    public class GetRecommendedCouponsQueryHandler : IQueryHandler<RecommendedCouponDTO, Task<FilteredCoupon>>
    {
        #region References
        private readonly ILogger<GetRecommendedCouponsQueryHandler> _logger;
        private readonly ICouponRepository _couponRepository;
        #endregion

        #region Public Members
        public GetRecommendedCouponsQueryHandler(
            ILogger<GetRecommendedCouponsQueryHandler> logger,
            ICouponRepository couponRepository)
        {
            _logger = logger;
            _couponRepository = couponRepository;
        }

        /// <summary>
        /// Gets Recommended Coupons
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<FilteredCoupon> ExecuteQuery(
            RecommendedCouponDTO request)
        {
            _logger.LogInformation("GetRecommendedCouponsQueryHandler triggered to retrieve recommended coupons");

            return new FilteredCoupon()
            {
                Coupons = new List<BaseCoupon>(),
                Brands = new List<CouponBrand>(),
                Category = new List<CouponCategory>(),
                PaginationInfo = new CouponPagination() { StartRecord = 10, TotalRecords = 10, ExpectedRecordsPerPage = 10, TotalRecordsPerPage = 5 }
            };

            //To-Do call Data layer
            //return await _couponRepository.GetRecommendedCouponsData(request);
        }

        #endregion

    }
}
