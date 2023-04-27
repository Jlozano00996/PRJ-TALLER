using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taller.Application.Contracts.DbContexts;
using Taller.Domain.EntityModels;

namespace Taller.Application.Contracts.Repositories
{
    public interface IPrecioRepository : IRepository<Precio>
    {
    }
}
