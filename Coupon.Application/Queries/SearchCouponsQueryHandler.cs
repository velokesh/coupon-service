using AutoMapper;
using Coupon.Application.Interfaces;
using Coupon.Domain.Models;
using Coupon.Infrastructure.Interfaces;
using Coupon.Infrastructure.Repositories.Database.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coupon.Application.Queries
{
    public class SearchCouponsQueryHandler : IQueryHandler<CouponSearch, FilteredCoupon>
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
        public FilteredCoupon ExecuteQuery(
            CouponSearch request)
        {
            _logger.LogInformation("SearchCouponsQueryHandler triggered to retrieve recommended coupons");

            var filteredCoupons = _couponOperation.GetCoupons(request).ToList();
            var coupons = _couponOperation.GetCoupons(new CouponSearch()).ToList();
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
                Coupons = _mapper.Map<List<CouponInfo>, List<BaseCoupon>>(filteredCoupons),
                Brands = brands,
                Category = categories,
                PaginationInfo = new CouponPagination()
                {
                    StartRecord = 10,
                    TotalRecords = filteredCoupons.Count(),
                    ExpectedRecordsPerPage = 10,
                    TotalRecordsPerPage = 5
                }
            };
        }

        #endregion

    }
}
