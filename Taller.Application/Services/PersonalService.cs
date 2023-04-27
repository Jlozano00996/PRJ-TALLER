using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Taller.Application.Contracts.Repositories;
using Taller.Application.Contracts.Services;
using Taller.Domain.EntityModels;

namespace Taller.Application.Services
{
    public class PersonalService : IPersonalService
    {
        public PersonalService(IPersonalRepository personalRepository)
        {
            _personalRepository = personalRepository;
        }
        readonly IPersonalRepository _personalRepository;
        public void Delete(int id)
        {
            Delete(Get(id));
        }

        public void Delete(Personal personal)
        {
            if (personal == null)
            {
                throw new ArgumentNullException(nameof(personal));
            }
            _personalRepository.Delete(personal);
            _personalRepository.Save();
        }

        public Personal Get(int id)
        {
            return _personalRepository.Get(s=>s.PersonalId == id);
        }

        public void Insert(Personal personal)
        {
            _personalRepository.Insert(personal);
            _personalRepository.Save();
        }

        public IEnumerable<Personal> List(Expression<Func<Personal, bool>> predicate = null)
        {
            return _personalRepository.GetAll(predicate);
        }

        public void Update(Personal personal)
        {
            if (personal == null) 
            {
                throw new ArgumentNullException(nameof(personal));
            }
            _personalRepository.Update(personal);
            _personalRepository.Save();
        }
    }
}
