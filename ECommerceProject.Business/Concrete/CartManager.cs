using System;
using System.Collections.Generic;
using System.Text;
using ECommerceProject.Business.Abstract;
using ECommerceProject.Business.Constants;
using ECommerceProject.Core.Utilities.Results;
using ECommerceProject.DataAccess.Abstract;
using ECommerceProject.Entities.Concrete;

namespace ECommerceProject.Business.Concrete
{
    public class CartManager : ICartService
    {
        private ICartRepository _cartRepository;

        public CartManager(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public IResult InitializeCart(string userId)
        {
            _cartRepository.Add(new Cart() { UserId = userId });
            return new SuccessResult(Messages.CardInitialized);
        }

        public IDataResult<Cart> GetCartByUserId(string userId)
        {
            return new SuccessDataResult<Cart>(_cartRepository.GetCartByUserId(userId));
        }

        public IResult AddToCart(string userId, int productId, int quantity)
        {
            var cart = GetCartByUserId(userId).Data;
            if (cart != null)
            {
                var index = cart.CartItems.FindIndex(I => I.ProductId == productId);

                if (index < 0)
                {
                    cart.CartItems.Add(new CartItem()
                    {
                        ProductId = productId,
                        Quantity = quantity,
                        CartId = cart.Id
                    });
                }
                else
                {
                    cart.CartItems[index].Quantity += quantity;
                }
                _cartRepository.Update(cart);
                return new SuccessResult(Messages.AddToCard);
            }

            return new ErrorResult(Messages.NotAddToCard);
        }

        public IResult DeleteFromCart(string userId, int productId)
        {
            var cart = GetCartByUserId(userId).Data;
            if (cart != null)
            {
                _cartRepository.DeleteFromCart(cart.Id, productId);
            }

            return new SuccessResult();
        }

        public IResult ClearCart(int cartId)
        {
            _cartRepository.ClearCart(cartId);
            return new SuccessResult();
        }
    }
}
