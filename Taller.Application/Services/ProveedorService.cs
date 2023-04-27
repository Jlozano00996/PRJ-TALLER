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
    public class ProveedorService : IProveedorService
    {
        public ProveedorService(IProveedorRepository proveedoresRepository)
        {
            _proveedoresRepository = proveedoresRepository;
        }
        readonly IProveedorRepository _proveedoresRepository;
        public void Delete(int id)
        {
            Delete(Get(id));
        }

        public void Delete(Proveedor proveedor)
        {
            if (proveedor == null) 
            {
                throw new ArgumentNullException(nameof(proveedor));
            }
            _proveedoresRepository.Delete(proveedor);
            _proveedoresRepository.Save();
        }

        public Proveedor Get(int id)
        {
            return _proveedoresRepository.Get(s => s.ProveedorId == id);
        }

        public void Insert(Proveedor proveedor)
        {
            _proveedoresRepository.Insert(proveedor);
            _proveedoresRepository.Save();
        }

        public IEnumerable<Proveedor> List(Expression<Func<Proveedor, bool>> Predicate = null)
        {
            return _proveedoresRepository.GetAll(Predicate);
        }

        public void Update(Proveedor proveedor)
        {
            if (proveedor == null) 
            {
                throw new ArgumentNullException(nameof(proveedor));
            }
            _proveedoresRepository.Update(proveedor);
            _proveedoresRepository.Save();
        }
    }
}
