using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Taller.Domain.InputModels
{
    public class ForgotPasswordModel
    {
        [Required]
        [Display(Name = "Password")]
        public string password { get; set; }

        [Required]
        [Compare("password", ErrorMessage = "The password and confirmation password do not match.")]
        [Display(Name = "Confirm Password")]
        public string confirmPassword { get; set; }

        [Display(Name = "Email")]
        public string email { get; set; }

        public string token { get; set; }
    }
}
