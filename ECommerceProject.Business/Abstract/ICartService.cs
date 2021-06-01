using System;
using System.Collections.Generic;
using System.Text;
using ECommerceProject.Core.Utilities.Results;
using ECommerceProject.Entities.Concrete;

namespace ECommerceProject.Business.Abstract
{
    public interface ICartService
    {
        IResult InitializeCart(string userId);
        IDataResult<Cart> GetCartByUserId(string userId);
        IResult AddToCart(string userId, int productId, int quantity);
        IResult DeleteFromCart(string userId, int productId);
        IResult ClearCart(int cartId);
    }
}
