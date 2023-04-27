using Editorial.UI.Application.Contracts;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Taller.Application.Contracts.DbContexts;
using Taller.Application.Contracts.Identity;
using Taller.Domain.ComponentModels;
using Taller.Domain.EntityModels.Identity;
using Taller.Domain.InputModels;
using Taller.Identity.Services;
using Taller.Persistence.DbContexts;

namespace TallerUi.Controllers
{
    public class AccountController : Controller
    {
        public AccountController(IAccountService service, IUnitOfWork<ApplicationDbContext> unitOfWork, IEmailSender emailSender)
        {
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.Repository<Usuario>();
            _emailSender = emailSender;
            _service = service;
        }
        readonly IUnitOfWork<ApplicationDbContext> _unitOfWork;
        readonly IRepository<Usuario> _repository;
        readonly IEmailSender _emailSender;
        readonly IAccountService _service;

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(Register model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _service.Register(model.Email, model.Password);
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                }
                return RedirectToAction("Index", "Compras");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _service.Login(model.Email, model.Password);
                    return RedirectToAction("Index", "Compras");
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                }
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _service.Logout();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordModel model)
        {
            var token = await _service.GetPasswordResetToken(model.email).Result;
            var callback = Url.Action(nameof(ForgotPassword), "Account", new { model.email, token }, Request.Scheme);
            Email email =
                new Email
                {
                    Recipient = model.email,
                    Subject = "Link para reiniciar contraseña",
                    Body = callback
                };

            _emailSender.Send(email);
            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult ResetPassword(string token, string email)
        {
            var model = new ForgotPasswordModel { token = token, email = email };
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> ResetPassword(ForgotPasswordModel model)
        {
            var usuario = _repository.Get(s => s.Email == model.email);
            await _service.ResetPassword(usuario.Id, model.token, model.password);
            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        public ActionResult ChangePassword()
        {
            var usuario = _repository.Get(s => s.UserName == User.Identity.Name);
            ChangePasswordModel model = new ChangePasswordModel();
            model.userId = usuario.Id;
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> ChangePassword(ChangePasswordModel model)
        {
            var usuario = _repository.Get(s => s.UserName == User.Identity.Name);
            model.userId = usuario.Id;
            await _service.ChangePassword(model.userId, model.oldPassword, model.newPassword);
            return RedirectToAction("Index", "Home");
        }
    }
}
