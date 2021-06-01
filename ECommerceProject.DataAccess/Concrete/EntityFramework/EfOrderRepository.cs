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
    public class EfOrderRepository : EfEntityRepositoryBase<Order, DataContext>, IOrderRepository
    {
        
        public List<Order> GetOrders(string userId)
        {
            using var context = new DataContext();
            var orders = context.Orders.Include(I => I.OrderItems)
                .ThenInclude(I => I.Product).AsQueryable();

            if (!string.IsNullOrEmpty(userId))
            {
                orders = orders.Where(I => I.UserId == userId);
            }

            return orders.ToList();
        }
    }
}
