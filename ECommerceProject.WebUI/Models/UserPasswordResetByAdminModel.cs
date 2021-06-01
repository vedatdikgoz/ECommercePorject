using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceProject.WebUI.Models
{
    public class UserPasswordResetByAdminModel
    {
        public string UserId { get; set; }

        [Display(Name = "Yeni Şifre")]
        [Required]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
    }
}
