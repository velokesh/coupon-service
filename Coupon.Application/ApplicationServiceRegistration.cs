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
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //Dependency Injections
            services.AddScoped<IQueryHandler<RecommendedCoupon, Task<FilteredCoupon>>, GetRecommendedCouponsQueryHandler>();
            services.AddScoped<IQueryHandler<CouponSearch, Task<FilteredCoupon>>, SearchCouponsQueryHandler>();

            return services;
        }
    }
}
