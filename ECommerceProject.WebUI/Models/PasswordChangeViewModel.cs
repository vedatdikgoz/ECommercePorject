using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceProject.WebUI.Models
{
    public class PasswordChangeViewModel
    {

        [Display(Name = "Mevcut Şifreniz")]
        [Required(ErrorMessage = "Mevcut şifre alanı gereklidir")]
        [DataType(DataType.Password)]
        [MinLength(5,ErrorMessage = "Şifreniz en az 5 karakter olmalıdır")]
        public string PasswordCurrent { get; set; }

        [Display(Name = "Yeni Şifreniz")]
        [Required(ErrorMessage = "Yeni şifre alanı gereklidir")]
        [DataType(DataType.Password)]
        [MinLength(5, ErrorMessage = "Şifreniz en az 5 karakter olmalıdır")]
        public string PasswordNew { get; set; }

        [Display(Name = "Yeni Şifre Tekrarı")]
        [Required(ErrorMessage = "Şifre tekrar alanı gereklidir")]
        [DataType(DataType.Password)]
        [MinLength(5, ErrorMessage = "Şifreniz en az 5 karakter olmalıdır")]
        [Compare("PasswordNew",ErrorMessage = "Yeni şifre ile eşleşmemektedir")]
        public string PasswordConfirm { get; set; }
    }
}
