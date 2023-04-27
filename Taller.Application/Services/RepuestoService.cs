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
    public class RepuestoService : IRepuestoService
    {
        public RepuestoService(IRepuestoRepository repuestoRepository)
        {
            _repuestoRepository = repuestoRepository;
        }
        readonly IRepuestoRepository _repuestoRepository;
        public void Delete(int id)
        {
            Delete(Get(id));
        }

        public void Delete(Repuesto repuesto)
        {
            if (repuesto == null) 
            {
                throw new ArgumentNullException(nameof(repuesto));
            }
            _repuestoRepository.Delete(repuesto);
            _repuestoRepository.Save();
        }

        public Repuesto Get(int id)
        {
            return _repuestoRepository.Get(s=>s.RepuestoId == id);
        }

        public void Insert(Repuesto repuesto)
        {
            _repuestoRepository.Insert(repuesto);
            _repuestoRepository.Save();
        }

        public IEnumerable<Repuesto> List(Expression<Func<Repuesto, bool>> predicate = null)
        {
            return _repuestoRepository.GetAll(predicate);
        }

        public void Update(Repuesto repuesto)
        {
            if (repuesto == null) 
            {
                throw new ArgumentNullException(nameof(repuesto));
            }
            _repuestoRepository.Update(repuesto);
            _repuestoRepository.Save();
        }
    }
}
