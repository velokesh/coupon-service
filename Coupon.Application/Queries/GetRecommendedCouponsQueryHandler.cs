using Coupon.Application.Contracts;
using Coupon.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coupon.Application.Queries
{
    public class GetRecommendedCouponsQueryHandler : IRequestHandler<GetRecommendedCouponsQuery, FilteredCoupon>
    {
        private readonly ICouponRepository _couponRepository;

        public GetRecommendedCouponsQueryHandler(ICouponRepository couponRepository) 
        {
            _couponRepository = couponRepository;
        }

        public async Task<FilteredCoupon> Handle(GetRecommendedCouponsQuery request, CancellationToken cancellationToken)
        {
            return new FilteredCoupon() { 
                Coupons = new List<BaseCoupon>(),
                Brands = new List<CouponBrand>(),
                Category = new List<CouponCategory>(),
                PaginationInfo = new CouponPagination() { StartRecord=10, TotalRecords=10, ExpectedRecordsPerPage=10, TotalRecordsPerPage=5}
            };

            //To-Do call Data layer
            //return await _couponRepository.GetRecommendedCouponsData(request);
        }

    }
}
