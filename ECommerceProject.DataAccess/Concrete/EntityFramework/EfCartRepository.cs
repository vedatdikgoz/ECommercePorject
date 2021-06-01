using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ECommerceProject.Core.DataAccess.EntityFramework;
using ECommerceProject.DataAccess.Abstract;
using ECommerceProject.DataAccess.Concrete.Context;
using ECommerceProject.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace ECommerceProject.DataAccess.Concrete.EntityFramework
{
    public class EfCartRepository :EfEntityRepositoryBase<Cart,DataContext>, ICartRepository
    {
        public Cart GetCartByUserId(string userId)
        {
            using var context = new DataContext();
            return context.Carts.Include(I => I.CartItems)
                .ThenInclude(I => I.Product).FirstOrDefault(I => I.UserId == userId);
        }

        public void DeleteFromCart(int cartId, int productId)
        {
            using var context = new DataContext();
            var cmd = @"delete from CartItems where CartId=@p0 and ProductId=@p1";
            context.Database.ExecuteSqlRaw(cmd,cartId,productId);
        }

        public void ClearCart(int cartId)
        {
            using var context = new DataContext();
            var cmd = @"delete from CartItems where CartId=@p0";
            context.Database.ExecuteSqlRaw(cmd, cartId);

        }


        public override void Update(Cart entity)
        {
            using var context = new DataContext();
            context.Carts.Update(entity);
            context.SaveChanges();
        }
    }
}
