#region References
using AutoMapper;
using Coupon.Application.Interfaces;
using Coupon.Domain.Models;
using Coupon.API.Protos;
using Grpc.Core;
#endregion

namespace Coupon.API.Services
{
    public class CouponSearchService : Protos.CouponSearchService.CouponSearchServiceBase 
    {
        #region Declarations
        private readonly ILogger<CouponSearchService> _logger;
        private readonly IMapper _mapper;
        private readonly IQueryHandler<CouponSearch, Task<FilteredCoupon>> _searchCoupons;
        #endregion

        #region Public Memebers
        /// <summary>
        /// Initializes its members
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="mediator"></param>
        /// <param name="logger"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public CouponSearchService(
            ILogger<CouponSearchService> logger,
            IMapper mapper,
            IQueryHandler<CouponSearch, Task<FilteredCoupon>> searchCoupons)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _searchCoupons = searchCoupons ?? throw new ArgumentNullException(nameof(searchCoupons));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }


        /// <summary>
        /// Gets Recommended Coupons
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override async Task<CouponSearchResponse> SearchCoupons(
            CouponFilterRequest request,
            ServerCallContext context)
        {
            _logger.LogInformation("Begin grpc call from method {Method} for search Coupons {request}", context.Method, request);
            _logger.LogTrace("Sending query to get search filter coupons");

            CouponSearchResponse filteredCoupon = new();
            try
            {
                var couponRequestModel = _mapper.Map<CouponSearch>(request);
                var responseData = await _searchCoupons.ExecuteQuery(couponRequestModel);

                filteredCoupon = _mapper.Map<CouponSearchResponse>(responseData);
                return filteredCoupon;
            }
            catch(Exception ex)
            {
                _logger.LogError("Error in SearchCoupons service {msg}", ex.Message);
                return filteredCoupon;
            }
        }

        #endregion

        
    }
}