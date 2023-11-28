using Coupon.Application.Contracts;
using Coupon.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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
