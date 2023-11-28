#region References
using Coupon.Application.Interfaces;
using Coupon.Application.Queries;
using Coupon.Domain.Models;
using Microsoft.Extensions.DependencyInjection;
#endregion

namespace Coupon.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddCouponApplicationServices(this IServiceCollection services)
        {

            //Dependency Injections
            services.AddScoped<IQueryHandler<RecommendedCouponDTO, Task<FilteredCoupon>>, GetRecommendedCouponsQueryHandler>();

            return services;
        }
    }
}
