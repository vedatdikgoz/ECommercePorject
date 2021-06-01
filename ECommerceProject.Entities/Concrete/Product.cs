using System;
using System.Collections.Generic;
using System.Text;
using ECommerceProject.Core.Entities;

namespace ECommerceProject.Entities.Concrete
{
   public class Product:IEntity
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Brand { get; set; }
        public short Stock { get; set; }
        public double? Price { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public bool IsApproved { get; set; }
        public bool IsHome { get; set; }

        public List<ProductCategory> ProductCategories { get; set; }
    }
}
