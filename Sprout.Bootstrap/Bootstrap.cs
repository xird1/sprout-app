using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sprout.Exam.Business.Services;
using Sprout.Exam.Business.Services.Interfaces;
using Sprout.Exam.Business.Validator;
using Sprout.Exam.Common.Models;
using Sprout.Exam.DataAccess.Data;
using Sprout.Exam.DataAccess.Repositories;
using Sprout.Exam.DataAccess.Repositories.Interfaces;

namespace Sprout.Exam.Bootstrap
{
    public static class Bootstrap
    {
        public static IServiceCollection RegisterApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    config.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddIdentityServer()
                .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<EmployeeValidator>();

            return services;
        }

    }
}
