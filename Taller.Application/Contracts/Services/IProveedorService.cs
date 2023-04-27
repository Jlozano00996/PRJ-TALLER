using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Taller.Domain.EntityModels;

namespace Taller.Application.Contracts.Services
{
    public interface IProveedorService
    {
        Proveedor Get(int id);
        IEnumerable<Proveedor> List(Expression<Func<Proveedor, bool>>Predicate = null);
        void Insert(Proveedor proveedor);
        void Update(Proveedor proveedor);
        void Delete(int id);
        void Delete(Proveedor proveedor);
        
    }
}
