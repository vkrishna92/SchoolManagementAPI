using System;
using Core.Common.Interfaces;
using Data.Common;

namespace SchoolManagementAPI.Extensions
{
    public static class ApplicationServiceExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();
            return services;
        }
    }
}

