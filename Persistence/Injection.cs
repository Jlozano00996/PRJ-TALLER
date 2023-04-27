using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taller.Application.Contracts.DbContexts;
using Taller.Application.Contracts.Repositories;
using Taller.Domain.EntityModels;
using Taller.Domain.EntityModels.Identity;
using Taller.Persistence.DbContexts;
using Taller.Persistence.Repositories;

namespace Taller.Persistence
{
    public static class Injection
    {
        public static IServiceCollection AddPersistenceServices
           (this IServiceCollection services,
             IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>
                (options =>
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IApplicationDbContext>
                (options =>
                    options.GetService<ApplicationDbContext>());


            services.AddUnitOfWork<ApplicationDbContext>()
                .AddRepository<Compra, CompraRepository>()
                .AddRepository<Inventario, InventarioRepository>()
                .AddRepository<Personal, PersonalRepository>()
                .AddRepository<Precio, PrecioRepository>()
                .AddRepository<Proveedor, ProveedorRepository>()
                .AddRepository<Repuesto, RepuestoRepository>()
                .AddRepository<Usuario, UsuarioRepository>()
                ;

            return services;
        }
    }
}
