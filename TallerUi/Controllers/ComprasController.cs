using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using Taller.Application.Contracts.DbContexts;
using Taller.Domain.EntityModels;
using Taller.Persistence.DbContexts;

namespace TallerUi.Controllers
{
    public class ComprasController : Controller
    {
        public ComprasController(IUnitOfWork<ApplicationDbContext> unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.Repository<Compra>();
            _repositoryProveedor = _unitOfWork.Repository<Proveedor>();
        }
        readonly IUnitOfWork<ApplicationDbContext> _unitOfWork;
        readonly IRepository<Compra> _repository;
        readonly IRepository<Proveedor> _repositoryProveedor;

        public ActionResult Index()
        {
            Expression<Func<Compra, object>>[] include = { i => i.proveedor };
            var compras = _repository.GetAll(includes: include);
            return View(compras);
        }

        [HttpGet]
        public ActionResult Upsert(int id = 0)
        {
            var model = new Taller.Domain.ViewModels.Compra
            {
                compra =
                    id == 0
                        ? new Compra()
                        : _repository.Get(s => s.CompraId == id),
                proveedores = _repositoryProveedor.GetAll().ToList()
            };


            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Upsert(Taller.Domain.ViewModels.Compra input)
        {
            ModelState.Remove("proveedores");
            ModelState.Remove("compra.Proveedor");
            if (ModelState.IsValid)
            {
                try
                {
                    if (input.compra.CompraId == 0)
                    {
                        _repository.Insert(input.compra);
                    }
                    else
                    {
                        _repository.Update(input.compra);
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
                var compra = _repository.Get(s => s.CompraId == id);
                if (compra == null)
                {
                    return Json(new { success = false, message = "Autor no encontrado." });
                }
                _repository.Delete(compra);
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
