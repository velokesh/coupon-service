﻿#region References
using AutoMapper;
using Coupon.Application.Interfaces;
using Coupon.Domain.Models;
using Coupon.Infrastructure.Repositories.DTO;
using Coupon.Infrastructure.Repositories.Interfaces;
using Microsoft.Extensions.Logging;
#endregion

namespace Coupon.Application.Queries
{
    public class GetRecommendedCouponsQueryHandler : IQueryHandler<RecommendedCouponDTO, Task<FilteredCoupon>>
    {
        #region References
        private readonly ILogger<GetRecommendedCouponsQueryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly ICouponOperation _couponOperation;
        #endregion

        #region Public Members
        public GetRecommendedCouponsQueryHandler(
            ILogger<GetRecommendedCouponsQueryHandler> logger,
            IMapper mapper,
            ICouponOperation couponOperation)
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
        public async Task<FilteredCoupon> ExecuteQuery(
            RecommendedCouponDTO request)
        {
            _logger.LogInformation("GetRecommendedCouponsQueryHandler triggered to retrieve recommended coupons");

            var coupons = await _couponOperation.GetCoupons();

            return new FilteredCoupon()
            {
                Coupons = _mapper.Map<List<CouponDTO>, List<BaseCoupon>>(coupons.ToList()),
                Brands = new List<CouponBrand>(),
                Category = new List<CouponCategory>(),
                PaginationInfo = new CouponPagination() {
                    StartRecord = 10,
                    TotalRecords = coupons.Count(),
                    ExpectedRecordsPerPage = 10,
                    TotalRecordsPerPage = 5
                }
            };
        }

        #endregion

    }
}
