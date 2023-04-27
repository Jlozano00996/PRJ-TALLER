using Taller.Application.Contracts.DbContexts;
using Taller.Application.Contracts.Identity;
using Taller.Domain.EntityModels;
using Taller.Domain.EntityModels.Identity;
using Taller.Domain.InputModels;
using Taller.Identity.Services;
using Taller.Persistence.DbContexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace TallerUi.Controllers
{
    public class RepuestoController : Controller
    {
        public RepuestoController(IUnitOfWork<ApplicationDbContext> unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.Repository<Repuesto>();
            _repositoryCompras = _unitOfWork.Repository<Compra>();
        }
        readonly IUnitOfWork<ApplicationDbContext> _unitOfWork;
        readonly IRepository<Repuesto> _repository;
        readonly IRepository<Compra> _repositoryCompras;

        public ActionResult Index()
        {
            Expression<Func<Repuesto, object>>[] include = { i => i.compra };
            var repuesto = _repository.GetAll(includes: include);
            return View(repuesto);
        }

        [HttpGet]
        public ActionResult Upsert(int id = 0)
        {
            var model = new Taller.Domain.ViewModels.Repuesto
            {
                repuesto =
                      id == 0
                          ? new Repuesto()
                          : _repository.Get(s => s.RepuestoId == id),
                compras = _repositoryCompras.GetAll().ToList()
            };


            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Upsert(Taller.Domain.ViewModels.Repuesto input)
        {
            ModelState.Remove("compras");
            ModelState.Remove("repuesto.Compra");
            if (ModelState.IsValid)
            {
                try
                {
                    if (input.repuesto.RepuestoId == 0)
                    {
                        _repository.Insert(input.repuesto);
                    }
                    else
                    {
                        _repository.Update(input.repuesto);
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
                var repuesto = _repository.Get(s => s.RepuestoId == id);
                if (repuesto == null)
                {
                    return Json(new { success = false, message = "Autor no encontrado." });
                }
                _repository.Delete(repuesto);
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
