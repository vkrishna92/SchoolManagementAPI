using System;
using Core.Common.Models;
using Data.DataAccess;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace SchoolManagementAPI.Extensions
{
	public static class IdentityServiceExtensions
	{
        public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration config)
        {
            var builder = services.AddIdentityCore<IdentityUser>()
                //.AddRoleManager<RoleManager<AppRole>>()
                .AddEntityFrameworkStores<DataContext>()
                .AddDefaultTokenProviders();            
            services.AddAuthentication();
            return services;
        }
    }
}

