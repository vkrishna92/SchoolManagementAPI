using System;
using Core.Common.Interfaces;
using Core.StudentModule.Models;
using Core.StudentModule.Services;
using Data.Common;
using Data.Student;
using NuGet.Protocol.Core.Types;

namespace SchoolManagementAPI.Extensions
{
    public static class ApplicationServiceExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IRepository<Core.StudentModule.Models.Student>, Repository<Core.StudentModule.Models.Student>>();
            //services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            //services.AddScoped<IRepository<Student>, Repository<Student>>();
            //services.AddScoped<IStudentService, StudentService>();

            return services;
        }
    }
}

