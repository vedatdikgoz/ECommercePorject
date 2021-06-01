using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ECommerceProject.Entities.Concrete;


namespace ECommerceProject.WebUI.Models
{
    public class ProductAddViewModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        [Display(Name = "Uzantı")]
        [Required(ErrorMessage = "Uzantı alanı boş geçilemez")]
        public string Url { get; set; }
        [Display(Name = "Fiyat")]
        [Required(ErrorMessage = "Fiyat alanı boş geçilemez")]
        [Range(500,30000, ErrorMessage="Lütfen 500 ile 30000 arsında bir değer giriniz")]
        public double? Price { get; set; }
        [Display(Name = "Açıklama")]
        [Required(ErrorMessage = "Açıklama alanı boş geçilemez")]
        public string Description { get; set; }
        [Display(Name = "Resim")]
        public string ImageUrl { get; set; }
        public bool IsApproved { get; set; }
        public bool IsHome { get; set; }

        [Display(Name = "Marka")]
        public string Brand { get; set; }

        [Display(Name = "Adet")]
        public short Stock { get; set; }

        public List<Category> SelectedCategories { get; set; }
    }
}
