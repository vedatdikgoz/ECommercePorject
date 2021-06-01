using System;
using System.Collections.Generic;
using System.Text;
using ECommerceProject.Core.DataAccess;
using ECommerceProject.Entities.Concrete;


namespace ECommerceProject.DataAccess.Abstract
{
    public interface ICartRepository:IEntityRepository<Cart>
    {
        Cart GetCartByUserId(string userId);
        void DeleteFromCart(int cartId, int productId);
        void ClearCart(int cartId);
    }
}
