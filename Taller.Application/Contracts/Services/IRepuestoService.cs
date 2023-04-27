using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Taller.Domain.EntityModels;

namespace Taller.Application.Contracts.Services
{
    public interface IRepuestoService
    {
        Repuesto Get(int id);
        IEnumerable<Repuesto> List(Expression<Func<Repuesto,bool>>predicate = null);
        void Insert(Repuesto repuesto);
        void Update(Repuesto repuesto);
        void Delete(int id);
        void Delete(Repuesto repuesto);
    }
}
