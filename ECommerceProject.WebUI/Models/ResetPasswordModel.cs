 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceProject.WebUI.Models
{
    public class ResetPasswordModel
    {
        [Required]
        public string Token { get; set; }


        [Display(Name = "Email Adresiniz")]
        [Required(ErrorMessage = "Email alanı gereklidir.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Display(Name = "Şifreniz")]
        [Required(ErrorMessage = "Şifre alanı gereklidir.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


    }
}
