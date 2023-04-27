using Taller.Application.Contracts.DbContexts;
using Taller.Domain.EntityModels.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller.Application.Contracts.Repositories
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
    }
}
