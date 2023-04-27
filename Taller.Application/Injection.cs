using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taller.Application.Contracts.Repositories;
using Taller.Application.Contracts.Services;
using Taller.Application.Services;

namespace Taller.Application
{
    public static class Injection
    {
        public static IServiceCollection AddApplicationServices
           (this IServiceCollection services,
             IConfiguration configuration)
        {
            return services;
        }
    }
}
