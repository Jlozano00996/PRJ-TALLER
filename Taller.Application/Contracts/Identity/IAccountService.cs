using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller.Application.Contracts.Identity
{
    public interface IAccountService
    {
        Task Register(string email, string password);
        Task Login(string email, string password);
        Task Logout();
        Task<bool> ChangePassword(string userId, string oldPassword, string newPassword);
        Task<bool> ResetPassword(string userId, string token, string newPassword);
        Task<Task<string>> GetPasswordResetToken(string userEmail);
    }
}
