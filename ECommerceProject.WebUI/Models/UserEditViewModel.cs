using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace ECommerceProject.WebUI.Models
{
    public class UserEditViewModel
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
        public string PhoneNumber { get; set; }


        [Required(ErrorMessage = "Email alanı gereklidir.")]
        [EmailAddress(ErrorMessage = "Geçerli bir email adresi giriniz.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        

        [Display(Name = "Profil Resim")]
        public string Picture { get; set; }


        [Display(Name = "Doğum Tarihi")]
        [DataType(DataType.Date)]
        public DateTime? BirthDay { get; set; }
    
    }
}
