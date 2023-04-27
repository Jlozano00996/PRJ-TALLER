using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Taller.Domain.EntityModels;

namespace Taller.Application.Contracts.Services
{
    public interface IPersonalService
    {
        Personal Get(int id);
        IEnumerable<Personal> List(Expression<Func<Personal,bool>> predicate = null);
        void Insert(Personal personal);
        void Update(Personal personal);
        void Delete(int id);
        void Delete(Personal personal);

    }
}
