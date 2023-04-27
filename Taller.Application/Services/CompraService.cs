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
    public class CompraService : ICompraService
    {
        public CompraService(ICompraRepository repository)
        {
            _repository = repository;      
        }
        readonly ICompraRepository _repository;
        public void Delete(int id)
        {
            _repository.Delete(Get(id));
        }

        public void Delete(Compra compra)
        {
            if (compra == null) 
            {
                throw new ArgumentNullException(nameof(compra));
            }
            _repository.Delete(compra);
            _repository.Save();
        }

        public Compra Get(int id)
        {
            return _repository.Get(s => s.CompraId == id);
        }

        public void Insert(Compra compra)
        {
            _repository.Insert(compra);
            _repository.Save();
        }

        public IEnumerable<Compra> List(Expression<Func<Compra, bool>> predicate = null)
        {
            return _repository.GetAll(predicate);
        }

        public void Update(Compra compra)
        {
            if (compra == null) 
            {
                throw new ArgumentException(nameof(compra));
            }
            _repository.Update(compra);
            _repository.Save();
        }
    }
}
