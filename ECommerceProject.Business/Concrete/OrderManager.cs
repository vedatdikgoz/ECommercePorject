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
   public class OrderManager:IOrderService
   {
       private IOrderRepository _orderRepository;

       public OrderManager(IOrderRepository orderRepository)
       {
           _orderRepository = orderRepository;
       }

        public IResult Add(Order entity)
        {
            _orderRepository.Add(entity);

            return new SuccessResult(Messages.OrderAdded);
        }

        public IDataResult<int> CountOrder()
        {
            return new SuccessDataResult<int>(_orderRepository.GetAll().Count);
        }

        public IDataResult<List<Order>> GetOrders(string userId)
        {
            return new SuccessDataResult<List<Order>>(_orderRepository.GetOrders(userId));
        }
    }
}
