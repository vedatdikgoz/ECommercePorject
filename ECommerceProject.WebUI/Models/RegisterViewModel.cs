using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceProject.WebUI.Models
{
    public class RegisterViewModel
    {

        [Required(ErrorMessage = "Kullanıcı adı gereklidir.")]
        [Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Ad alanı gereklidir.")]
        [Display(Name = "Ad")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "Soyad alanı gereklidir.")]
        [Display(Name = "Soyad")]
        public string LastName { get; set; }


        [Display(Name = "Telefon")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }


        [Required(ErrorMessage = "Email alanı gereklidir.")]
        [EmailAddress(ErrorMessage = "Geçerli bir email adresi giriniz.")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Şifre alanı gereklidir.")]
        [Display(Name = "şifre")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
