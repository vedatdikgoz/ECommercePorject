using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ECommerceProject.Entities.Concrete;


namespace ECommerceProject.WebUI.Models
{
    public class CategoryAddViewModel
    {
        public int CategoryId { get; set; }
        [Display(Name = "Ad")]
        [Required(ErrorMessage = "Ad alanı boş geçilemez")]
        public string Name { get; set; }
        [Display(Name = "Uzantı")]
        [Required(ErrorMessage = "Uzantı adı alanı boş geçilemez")]
        public string Url { get; set; }
        public List<Product> Products { get; set; }
    }
}
