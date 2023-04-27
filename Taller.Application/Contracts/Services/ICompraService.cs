using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Taller.Domain.EntityModels;

namespace Taller.Application.Contracts.Services
{
    public interface ICompraService
    {
        Compra Get(int id);
        IEnumerable<Compra> List(Expression<Func<Compra, bool>> predicate = null);
        void Insert(Compra compra);
        void Update(Compra compra);
        void Delete(int id);
        void Delete(Compra compra);
    }
}
