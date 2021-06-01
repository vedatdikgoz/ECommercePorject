using System;
using System.Collections.Generic;
using System.Text;
using ECommerceProject.Core.Entities;

namespace ECommerceProject.Entities.Concrete
{
    public class ProductCategory:IEntity
    {
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
