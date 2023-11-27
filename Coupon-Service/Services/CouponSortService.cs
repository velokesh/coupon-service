using AutoMapper;
using Coupon.Application.Queries;
using Coupon_Service.Protos;
using Grpc.Core;
using MediatR;

namespace Coupon_Service.Services
{
    public class CouponSortService : Protos.CouponSortService.CouponSortServiceBase
    {
        private readonly ILogger<CouponSortService> _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public CouponSortService(IMapper mapper, IMediator mediator, ILogger<CouponSortService> logger) 
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public override async Task<FilteredCoupon> GetRecommendedCoupons(RecommendedCouponSearchRequest request, ServerCallContext context)
        {
            _logger.LogInformation("Begin grpc call from method {Method} for getting recommended Coupons {request}", context.Method, request);
            _logger.LogTrace("----- Sending query to get coupons");

            FilteredCoupon filteredCoupon = new FilteredCoupon();
            try
            {
                var couponRequestModel = _mapper.Map<Coupon.Domain.Models.RecommendedCouponDTO>(request);
                var query = new GetRecommendedCouponsQuery(couponRequestModel);
                var responseData = await _mediator.Send(query);

                filteredCoupon = _mapper.Map<FilteredCoupon>(responseData);
                return filteredCoupon;
            }
            catch
            {
                _logger.LogError("----- Error in GetRecommendedCoupons service");
                return filteredCoupon;
            }
        }
    }
}
