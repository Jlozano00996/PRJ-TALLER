using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using Taller.Application.Contracts.DbContexts;
using Taller.Domain.EntityModels;
using Taller.Persistence.DbContexts;

namespace TallerUi.Controllers
{
    public class InventarioController : Controller
    {

        public InventarioController(IUnitOfWork<ApplicationDbContext> unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.Repository<Inventario>();
            _repositoryCompras = _unitOfWork.Repository<Compra>();
        }
        readonly IUnitOfWork<ApplicationDbContext> _unitOfWork;
        readonly IRepository<Inventario> _repository;
        readonly IRepository<Compra> _repositoryCompras;

        public ActionResult Index()
        {
            Expression<Func<Inventario, object>>[] include = { i => i.compra };
            var inventario = _repository.GetAll(includes: include);
            return View(inventario);
        }

        [HttpGet]
        public ActionResult Upsert(int id = 0)
        {
            var model = new Taller.Domain.ViewModels.Inventario
            {
                inventario =
                    id == 0
                        ? new Inventario()
                        : _repository.Get(s => s.InventarioId == id),
                compras = _repositoryCompras.GetAll().ToList()
            };


            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Upsert(Taller.Domain.ViewModels.Inventario input)
        {
            ModelState.Remove("compras");
            ModelState.Remove("inventario.Compra");
            if (ModelState.IsValid)
            {
                try
                {
                    if (input.inventario.InventarioId == 0)
                    {
                        _repository.Insert(input.inventario);
                    }
                    else
                    {
                        _repository.Update(input.inventario);
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
                var inventario = _repository.Get(s => s.InventarioId == id);
                if (inventario == null)
                {
                    return Json(new { success = false, message = "Autor no encontrado." });
                }
                _repository.Delete(inventario);
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
