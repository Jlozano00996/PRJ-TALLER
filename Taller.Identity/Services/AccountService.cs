using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taller.Application.Contracts.Identity;
using Taller.Domain.EntityModels.Identity;

namespace Taller.Identity.Services
{
    public class AccountService : IAccountService
    {
        public AccountService(UserManager<Usuario> userManager,
            SignInManager<Usuario> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        readonly UserManager<Usuario> _userManager;
        readonly SignInManager<Usuario> _signInManager;
        public async Task Register(string email, string password)
        {
            var usuario = new Usuario { UserName = email, Email = email };
            var result = await _userManager.CreateAsync(usuario, password);

            if (!result.Succeeded)
            {
                StringBuilder builder = new StringBuilder();
                foreach (var error in result.Errors)
                {
                    builder.AppendLine(error.Description);
                }
                throw new Exception(builder.ToString());
            }
            await _signInManager.SignInAsync(usuario, isPersistent: false);
        }
        public async Task Login(string email, string password)
        {
            var result =
                await _signInManager.PasswordSignInAsync
                (email, password, isPersistent: false, lockoutOnFailure: false);

            if (!result.Succeeded)
            {
                throw new Exception("Invalid user and password combination.");
            }
        }

        public async Task<bool> ChangePassword(string userId, string oldPassword, string newPassword)
        {
            var usuario = await _userManager.FindByIdAsync(userId);

            var result =
                await _userManager.ChangePasswordAsync(usuario, oldPassword, newPassword);

            return result.Succeeded;
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<bool> ResetPassword(string userId, string token, string newPassword)
        {
            var usuario = await _userManager.FindByIdAsync(userId);

            var result =
                await _userManager.ResetPasswordAsync(usuario, token, newPassword);

            return result.Succeeded;
        }

        public async Task<Task<string>> GetPasswordResetToken(string userEmail)
        {
            var usuario = await _userManager.FindByEmailAsync(userEmail);
            return _userManager.GeneratePasswordResetTokenAsync(usuario);
        }
    }
}
