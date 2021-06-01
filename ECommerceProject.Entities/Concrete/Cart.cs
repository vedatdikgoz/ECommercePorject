using System;
using System.Collections.Generic;
using System.Text;
using ECommerceProject.Core.Entities;

namespace ECommerceProject.Entities.Concrete
{
    public class Cart:IEntity
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public List<CartItem> CartItems { get; set; }
    }
}
