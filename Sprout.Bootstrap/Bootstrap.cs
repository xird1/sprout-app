using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sprout.Business.Services;
using Sprout.Business.Services.Interfaces;
using Sprout.Business.Validator;
using Sprout.Common.Models;
using Sprout.DataAccess.Data;
using Sprout.DataAccess.Repositories;
using Sprout.DataAccess.Repositories.Interfaces;

namespace Sprout.Bootstrap
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
