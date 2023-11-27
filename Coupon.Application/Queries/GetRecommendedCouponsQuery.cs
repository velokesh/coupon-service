using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Coupon.Domain;

namespace Coupon.Application.Queries
{
    public record GetRecommendedCouponsQuery(Domain.Models.RecommendedCouponDTO RecommendedCouponDTO) : IRequest<Domain.Models.FilteredCoupon>;
    
}
