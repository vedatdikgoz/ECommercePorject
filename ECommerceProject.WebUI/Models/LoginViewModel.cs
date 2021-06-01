using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceProject.WebUI.Models
{
    public class LoginViewModel
    {
        [Display(Name="Email Adresi")]
        [Required(ErrorMessage = "Email alanı gereklidir.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Şifre alanı gereklidir.")]
        [DataType(DataType.Password)]
        [MinLength(5,ErrorMessage = "Şifreniz en az 5 karakter olmalıdır")]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }

        public bool RememberMe { get; set; }

    }
}
