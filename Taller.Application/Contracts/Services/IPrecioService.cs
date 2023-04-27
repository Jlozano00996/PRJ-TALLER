using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Taller.Domain.EntityModels;

namespace Taller.Application.Contracts.Services
{
    public interface IPrecioService
    {
        Precio Get(int id);
        IEnumerable<Precio> List(Expression<Func<Precio, bool>>predicate = null);
        void Insert(Precio precio);
        void Update(Precio precio);
        void Delete(int id);
        void Delete(Precio precio);
    }
}
