using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceProject.WebUI.Models
{
    public class RoleViewModel
    {
        [Display(Name = "Rol İsmi")]
        [Required(ErrorMessage = "Rol isim alanı gereklidir")]
        public string Name { get; set; }

        public string Id { get; set; }
    }
}
