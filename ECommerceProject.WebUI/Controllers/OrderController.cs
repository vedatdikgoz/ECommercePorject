using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceProject.Business.Abstract;
using ECommerceProject.WebUI.Identity;
using ECommerceProject.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Shopapp.WebUI.Models;

namespace ECommerceProject.WebUI.Controllers
{
    [Authorize]
    public class OrderController :Controller
    {
        private readonly IOrderService _orderService;
        private readonly UserManager<User> _userManager;
        public OrderController(IOrderService orderService, UserManager<User> userManager)
        {
            _orderService = orderService;
            _userManager = userManager;
        }
        public IActionResult GetOrders()
        {
            var userId = _userManager.GetUserId(User);
            var orders=_orderService.GetOrders(userId).Data;

            var orderListModel= new List<OrderListModel>();
            OrderListModel orderModel;
            foreach (var order in orders)
            {
                orderModel= new OrderListModel();

                orderModel.OrderId = order.Id;
                orderModel.OrderNumber = order.OrderNumber;
                orderModel.OrderDate = order.OrderDate;
                orderModel.Phone = order.Phone;
                orderModel.Email = order.Email;
                orderModel.Address = order.Address;
                orderModel.FirstName = order.FirstName;
                orderModel.LastName = order.LastName;
                orderModel.City = order.City;
                orderModel.OrderState = order.OrderState;
                orderModel.PaymentType = order.PaymentType;

                orderModel.OrderItems = order.OrderItems.Select(i => new OrderItemModel()
                {
                    OrderItemId = i.Id,
                    Name = i.Product.Name,
                    Price = i.Price,
                    Quantity = i.Quantity,
                    ImageUrl = i.Product.ImageUrl

                }).ToList();

                orderListModel.Add(orderModel);
            }


            return View("Orders",orderListModel);
        }

       
    }    
}
