using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taller.Application.Contracts.DbContexts;
using Taller.Domain.EntityModels;

namespace Taller.Persistence.DbContexts
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<Compra> compras { get; set; }
        public DbSet<Inventario> inventarios { get; set; }
        public DbSet<Personal> personales { get; set; }
        public DbSet<Precio> precios { get; set; }
        public DbSet<Proveedor> proveedores { get; set; }
        public DbSet<Repuesto> repuestos { get; set; }
    }
}
