using Taller.Application.Contracts.Repositories;
using Taller.Domain.EntityModels.Identity;
using Taller.Persistence.DbContexts;
using Taller.Identity.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller.Persistence.Repositories
{
    public class UsuarioRepository : Repository<Usuario>,
        IUsuarioRepository
    {
        public UsuarioRepository(ApplicationIdentityDbContext context)
            : base(context)
        {

        }

    }
}
