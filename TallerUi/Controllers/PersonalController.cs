using Microsoft.AspNetCore.Mvc;
using Taller.Application.Contracts.DbContexts;
using Taller.Domain.EntityModels;
using Taller.Persistence.DbContexts;

namespace TallerUi.Controllers
{
    public class PersonalController : Controller
    {

        public PersonalController(IUnitOfWork<ApplicationDbContext> unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.Repository<Personal>();
        }
        readonly IUnitOfWork<ApplicationDbContext> _unitOfWork;
        readonly IRepository<Personal> _repository;

        public ActionResult Index()
        {
            var personal = _repository.GetAll();
            return View(personal);
        }

        [HttpGet]
        public ActionResult Upsert(int id = 0)
        {
            var model =
                id == 0
            ? new Personal()
                : _repository.Get(s => s.PersonalId == id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Upsert(Personal input)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (input.PersonalId == 0)
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
                var personal = _repository.Get(s => s.PersonalId == id);
                if (personal == null)
                {
                    return Json(new { success = false, message = "Autor no encontrado." });
                }
                _repository.Delete(personal);
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
