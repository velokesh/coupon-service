#region References
using AutoMapper;
using Coupon.Application.Interfaces;
using Coupon.Domain.Models;
using Coupon_Service.Protos;
using Grpc.Core;
using FilteredCoupon = Coupon_Service.Protos.FilteredCoupon;
#endregion

namespace Coupon_Service.Services
{
    public class CouponSortService : Protos.CouponSortService.CouponSortServiceBase
    {
        #region Declarations
        private readonly ILogger<CouponSortService> _logger;
        private readonly IMapper _mapper;
        private readonly IQueryHandler<RecommendedCouponDTO, Task<Coupon.Domain.Models.FilteredCoupon>> _getRecommendedCoupons;
        #endregion

        #region Public Memebers
        /// <summary>
        /// Initializes its members
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="mediator"></param>
        /// <param name="logger"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public CouponSortService(
            ILogger<CouponSortService> logger,
            IMapper mapper,
            IQueryHandler<RecommendedCouponDTO, Task<Coupon.Domain.Models.FilteredCoupon>> getRecommendedCoupons)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _getRecommendedCoupons = getRecommendedCoupons ?? throw new ArgumentNullException(nameof(getRecommendedCoupons));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }


        /// <summary>
        /// Gets Recommended Coupons
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override async Task<FilteredCoupon> GetRecommendedCoupons(
            RecommendedCouponSearchRequest request,
            ServerCallContext context)
        {
            _logger.LogInformation("Begin grpc call from method {Method} for getting recommended Coupons {request}", context.Method, request);
            _logger.LogTrace("----- Sending query to get coupons");

            FilteredCoupon filteredCoupon = new();
            try
            {
                var couponRequestModel = _mapper.Map<RecommendedCouponDTO>(request);
                var responseData = await _getRecommendedCoupons.ExecuteQuery(couponRequestModel);

                filteredCoupon = _mapper.Map<FilteredCoupon>(responseData);
                return filteredCoupon;
            }
            catch(Exception ex)
            {
                _logger.LogError("----- Error in GetRecommendedCoupons service {msg}", ex.Message);
                return filteredCoupon;
            }
        }

        #endregion
    }
}
