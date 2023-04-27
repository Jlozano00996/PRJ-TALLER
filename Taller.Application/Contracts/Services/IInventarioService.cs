using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Taller.Domain.EntityModels;

namespace Taller.Application.Contracts.Services
{
    public interface IInventarioService
    {
        Inventario Get(int id);
        IEnumerable<Inventario> List(Expression<Func<Inventario,bool>> predicate = null);
        void Insert (Inventario inventario);
        void Update (Inventario inventario);
        void Delete(int id);
        void Delete (Inventario inventario);
    }
}
