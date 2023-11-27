using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace Coupon.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddCouponApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            return services;
        }
    }
}
