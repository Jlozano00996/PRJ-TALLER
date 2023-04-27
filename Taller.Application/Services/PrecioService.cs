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
    public class PrecioService : IPrecioService
    {
        public PrecioService(IPrecioRepository precioRepository)
        {
            _precioRepository = precioRepository;
        }
        readonly IPrecioRepository _precioRepository;
        public void Delete(int id)
        {
            Delete(Get(id));
        }

        public void Delete(Precio precio)
        {
            if (precio == null) 
            {
                throw new ArgumentNullException(nameof(precio));
            }
            _precioRepository.Delete(precio);
            _precioRepository.Save();
        }

        public Precio Get(int id)
        {
            return _precioRepository.Get(s=>s.PrecioId == id);
        }

        public void Insert(Precio precio)
        {
            _precioRepository.Insert(precio);
            _precioRepository.Save();
        }

        public IEnumerable<Precio> List(Expression<Func<Precio, bool>> predicate = null)
        {
            return _precioRepository.GetAll(predicate);
        }

        public void Update(Precio precio)
        {
            if (precio == null) 
            {
                throw new ArgumentNullException(nameof(precio));
            }
            _precioRepository.Update(precio);
            _precioRepository.Save();
        }
    }
}
