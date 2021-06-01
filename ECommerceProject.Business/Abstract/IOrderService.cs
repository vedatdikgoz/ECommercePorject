using System;
using System.Collections.Generic;
using System.Text;
using ECommerceProject.Core.Utilities.Results;
using ECommerceProject.Entities.Concrete;

namespace ECommerceProject.Business.Abstract
{
    public interface IOrderService
    {
        IResult Add(Order entity);
        IDataResult<List<Order>> GetOrders(string userId);
        IDataResult<int> CountOrder();

    }
}
