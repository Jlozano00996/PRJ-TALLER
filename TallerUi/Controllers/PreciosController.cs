using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using Taller.Application.Contracts.DbContexts;
using Taller.Domain.EntityModels;
using Taller.Persistence.DbContexts;

namespace TallerUi.Controllers
{
    public class PreciosController : Controller
    {

        public PreciosController(IUnitOfWork<ApplicationDbContext> unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.Repository<Precio>();
            _repositoryCompras = _unitOfWork.Repository<Compra>();
        }
        readonly IUnitOfWork<ApplicationDbContext> _unitOfWork;
        readonly IRepository<Precio> _repository;
        readonly IRepository<Compra> _repositoryCompras;

        public ActionResult Index()
        {
            Expression<Func<Precio, object>>[] include = { i => i.compra };
            var precios = _repository.GetAll(includes: include);
            return View(precios);
        }

        [HttpGet]
        public ActionResult Upsert(int id = 0)
        {
            var model = new Taller.Domain.ViewModels.Precio
            {
                precio =
                    id == 0
                        ? new Precio()
                        : _repository.Get(s => s.PrecioId == id),
                compras = _repositoryCompras.GetAll().ToList()
            };


            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Upsert(Taller.Domain.ViewModels.Precio input)
        {
            ModelState.Remove("compras");
            ModelState.Remove("precio.Compra");
            if (ModelState.IsValid)
            {
                try
                {
                    if (input.precio.PrecioId == 0)
                    {
                        _repository.Insert(input.precio);
                    }
                    else
                    {
                        _repository.Update(input.precio);
                    }
                    _unitOfWork.Save();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Internal Server Error.");
                }
            }
            return View(input);
        }

        public JsonResult Delete(int id = 0)
        {
            try
            {
                var precio = _repository.Get(s => s.PrecioId == id);
                if (precio == null)
                {
                    return Json(new { success = false, message = "Autor no encontrado." });
                }
                _repository.Delete(precio);
                _unitOfWork.Save();
            }
            catch
            {
                return Json(new { success = false, message = "Internal Server Error." });
            }
            return Json(new { success = true, message = "" });
        }
    }
}
