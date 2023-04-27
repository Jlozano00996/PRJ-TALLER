﻿using Taller.Domain.ComponentModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller.Domain.InputModels
{
    public class ChangePasswordModel
    {

     
        public string userId { get; set; }

        [Required]
        [Display(Name = "Old Password")]
        public string oldPassword { get; set; }

        [Required]
        [Display(Name = "New Password")]
        public string newPassword { get; set; }

        [Compare("newPassword", ErrorMessage = "The password and confirmation password do not match.")]
        [Display(Name = "Confirm New Password")]
        public string confirmNewPassword { get; set; }
    }
}