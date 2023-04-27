using Microsoft.AspNetCore.Mvc;
using Taller.Application.Contracts.DbContexts;
using Taller.Domain.EntityModels;
using Taller.Persistence.DbContexts;

namespace TallerUi.Controllers
{
    public class ProveedorController : Controller
    {
        public ProveedorController(IUnitOfWork<ApplicationDbContext> unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.Repository<Proveedor>();
        }
        readonly IUnitOfWork<ApplicationDbContext> _unitOfWork;
        readonly IRepository<Proveedor> _repository;

        public ActionResult Index()
        {
            var proveedor = _repository.GetAll();
            return View(proveedor);
        }

        [HttpGet]
        public ActionResult Upsert(int id = 0)
        {
            var model =
                id == 0
            ? new Proveedor()
                : _repository.Get(s => s.ProveedorId == id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Upsert(Proveedor input)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (input.ProveedorId == 0)
                    {
                        _repository.Insert(input);
                    }
                    else
                    {
                        _repository.Update(input);
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
                var proveedor = _repository.Get(s => s.ProveedorId == id);
                if (proveedor == null)
                {
                    return Json(new { success = false, message = "Autor no encontrado." });
                }
                _repository.Delete(proveedor);
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
