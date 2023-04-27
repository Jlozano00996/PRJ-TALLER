using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taller.Application.Contracts.Identity;
using Taller.Domain.EntityModels.Identity;
using Taller.Identity.DbContexts;
using Taller.Identity.Services;

namespace Taller.Identity
{
    public static class Injection
    {
        public static IServiceCollection AddIdentityServices
           (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<ApplicationIdentityDbContext>(options =>
            {
                options.UseSqlServer(
                      configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddIdentity<Usuario, IdentityRole>(options => {
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 2;
            }).AddEntityFrameworkStores<ApplicationIdentityDbContext>();

            services.AddScoped<IAccountService, AccountService>();//Después del paso 21

            return services;
        }
    }
}
