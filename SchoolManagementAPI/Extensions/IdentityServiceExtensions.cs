using System;
using Core.Common.Models;
using Data.DataAccess;
using Microsoft.AspNetCore.Identity;

namespace SchoolManagementAPI.Extensions
{
	public static class IdentityServiceExtensions
	{
        public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration config)
        {
            var builder = services.AddIdentity<AppUser, AppRole>()
                //.AddRoleManager<RoleManager<AppRole>>()
                .AddEntityFrameworkStores<DataContext>()
                .AddDefaultTokenProviders();
            /*
			builder = new IdentityBuilder(builder.UserType, builder.Services);
			builder.AddEntityFrameworkStores<AppIdentityDbContext>();
			builder.AddSignInManager<SignInManager<AppUser>>();
			*/
            services.AddAuthentication();
            return services;
        }
    }
}

