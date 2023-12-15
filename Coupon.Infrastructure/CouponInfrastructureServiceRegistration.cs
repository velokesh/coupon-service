using Coupon.Infrastructure.Interfaces;
using Coupon.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Coupon.Infrastructure
{
    public static class CouponInfrastructureServiceRegistration
    {
        public static IServiceCollection AddCouponInfrastructureServices(this IServiceCollection services)
        {
            services.AddSingleton<ICouponRepository, CouponRepository>();

            return services;
        }
    }
}
