using Coupon.Infrastructure.Repositories.Implementation;
using Coupon.Infrastructure.Repositories.Interaces;
using Microsoft.Extensions.DependencyInjection;

namespace Coupon.Infrastructure
{
    public static class CouponInfrastructureServiceRegistration
    {
        public static IServiceCollection AddCouponInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<ICouponRepository, CouponRepository>();
            return services;
        }
    }
}
