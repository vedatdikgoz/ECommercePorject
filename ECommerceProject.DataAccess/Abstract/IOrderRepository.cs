using System;
using System.Collections.Generic;
using System.Text;
using ECommerceProject.Core.DataAccess;
using ECommerceProject.Entities.Concrete;

namespace ECommerceProject.DataAccess.Abstract
{
    public interface IOrderRepository : IEntityRepository<Order>
    {
        List<Order> GetOrders(string userId);
    }
}
