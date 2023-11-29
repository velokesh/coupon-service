using Coupon.Infrastructure.Repositories.Implementation;
using Coupon.Infrastructure.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Coupon.Infrastructure
{
    public static class CouponInfrastructureServiceRegistration
    {
        public static IServiceCollection AddCouponInfrastructureServices(this IServiceCollection services)
        {
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;

            services.AddScoped<ICouponOperation, CouponOperation>();

            return services;
        }
    }
}
