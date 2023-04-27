using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taller.Application.Contracts.Repositories;
using Taller.Domain.EntityModels;
using Taller.Persistence.DbContexts;

namespace Taller.Persistence.Repositories
{
    public class PersonalRepository : Repository<Personal>, IPersonalRepository
    {
        public PersonalRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
