using Coupon.Infrastructure.Repositories.Database;
using Coupon.Infrastructure.Repositories.Implementation;
using Coupon.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Coupon.Infrastructure
{
    public static class CouponInfrastructureServiceRegistration
    {
        public static IServiceCollection AddCouponInfrastructureServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<CouponDbContext>(option => option.UseNpgsql(connectionString));

            services.AddScoped<ICouponOperation, CouponOperation>();

            return services;
        }
    }
}
