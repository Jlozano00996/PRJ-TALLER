using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller.Application.Contracts.DbContexts
{
    public interface IUnitOfWork<T>
       where T : DbContext
    {
        T Context { get; }
        void Save();
        IRepository<TEntity> Repository<TEntity>()
            where TEntity : class;
    }
}
