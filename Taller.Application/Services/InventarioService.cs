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
    public class InventarioService : IInventarioService
    {
        public InventarioService(IInventarioRepository inventarioRepository)
        {
            _inventarioRepository = inventarioRepository;
        }
        readonly IInventarioRepository _inventarioRepository;
        public void Delete(int id)
        {
            _inventarioRepository.Delete(Get(id));
        }

        public void Delete(Inventario inventario)
        {
            if (inventario == null) 
            {
                throw new ArgumentNullException(nameof(inventario));
            }
            _inventarioRepository.Delete(inventario);
            _inventarioRepository.Save();

        }

        public Inventario Get(int id)
        {
            return _inventarioRepository.Get(s=>s.InventarioId == id);
        }

        public void Insert(Inventario inventario)
        {
            _inventarioRepository.Insert(inventario);
            _inventarioRepository.Save();
        }

        public IEnumerable<Inventario> List(Expression<Func<Inventario, bool>> predicate = null)
        {
            return _inventarioRepository.GetAll(predicate);
        }

        public void Update(Inventario inventario)
        {
            if (inventario == null) 
            {
                throw new ArgumentNullException(nameof(inventario));
            }
            _inventarioRepository.Update(inventario);
            _inventarioRepository.Save();
        }
    }
}
