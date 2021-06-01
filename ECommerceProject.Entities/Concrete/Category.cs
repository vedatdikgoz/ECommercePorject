using System;
using System.Collections.Generic;
using System.Text;
using ECommerceProject.Core.Entities;

namespace ECommerceProject.Entities.Concrete
{
    public class Category:IEntity
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public List<ProductCategory> ProductCategories { get; set; }

    }
}
