using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taller.Domain.EntityModels;

namespace Taller.Application.Contracts.DbContexts
{
    public interface IApplicationDbContext
    {
        DbSet<Compra> compras {get;set;}
        DbSet<Inventario> inventarios {get;set;}
        DbSet<Personal> personales {get;set;}
        DbSet<Precio> precios {get;set;}
        DbSet<Proveedor> proveedores {get;set;}
        DbSet<Repuesto> repuestos {get;set;}
    }
}
