using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceProject.Business.Abstract;
using ECommerceProject.Entities.Concrete;
using ECommerceProject.WebUI.Identity;
using ECommerceProject.WebUI.Models;
using Iyzipay.Model;
using Iyzipay.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Shopapp.WebUI.Models;
using Iyzipay;
using Newtonsoft.Json;
using OrderItem = ECommerceProject.Entities.Concrete.OrderItem;

namespace ECommerceProject.WebUI.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly UserManager<User> _userManager;
        private readonly IOrderService _orderService;

        public CartController(ICartService cartService, UserManager<User> userManager, IOrderService orderService)
        {
            _userManager = userManager;
            _cartService = cartService;
            _orderService = orderService;
        }

        public void AddModelError(IdentityResult result)
        {

            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("", item.Description);
            }
        }

        public IActionResult Index()
        {
            var cart = _cartService.GetCartByUserId(_userManager.GetUserId(User)).Data;
            return View(new CartModel()
            {
                CartId = cart.Id,
                CartItems = cart.CartItems.Select(i => new CartItemModel()
                {
                    CartItemId = i.Id,
                    ProductId = i.ProductId,
                    Name = i.Product.Name,
                    Price = (double)i.Product.Price,
                    ImageUrl = i.Product.ImageUrl,
                    Quantity = i.Quantity

                }).ToList()
            });
        }


        [HttpPost]
        public IActionResult AddToCart(int productId, int quantity)
        {
            var userId = _userManager.GetUserId(User);

            _cartService.AddToCart(userId, productId, quantity);
            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult DeleteFromCart(int productId)
        {
            var userId = _userManager.GetUserId(User);
            _cartService.DeleteFromCart(userId, productId);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Checkout()
        {
            var cart = _cartService.GetCartByUserId(_userManager.GetUserId(User)).Data;

            var orderModel = new OrderModel();
            orderModel.CartModel = new CartModel()
            {
                CartId = cart.Id,
                CartItems = cart.CartItems.Select(i => new CartItemModel()
                {
                    CartItemId = i.Id,
                    ProductId = i.ProductId,
                    Name = i.Product.Name,
                    Price = (double)i.Product.Price,
                    ImageUrl = i.Product.ImageUrl,
                    Quantity = i.Quantity

                }).ToList()
            };
            return View(orderModel);

        }


        [HttpPost]
        public IActionResult Checkout(OrderModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = _userManager.GetUserId(User);
                var cart = _cartService.GetCartByUserId(userId).Data;

                model.CartModel = new CartModel()
                {
                    CartId = cart.Id,
                    CartItems = cart.CartItems.Select(i => new CartItemModel()
                    {
                        CartItemId = i.Id,
                        ProductId = i.ProductId,
                        Name = i.Product.Name,
                        Price = (double)i.Product.Price,
                        ImageUrl = i.Product.ImageUrl,
                        Quantity = i.Quantity

                    }).ToList()
                };
                var payment = PaymentProcess(model);

                if (payment.Status == "success")
                {
                    SaveOrder(model, payment, userId);
                    ClearCart(model.CartModel.CartId);
                    return View("Success");
                }
                else
                {
                    var msg = new AlertMessage()
                    {
                        Message = $"{payment.ErrorMessage}",
                        AlertType = "danger"
                    };

                    TempData["message"] = JsonConvert.SerializeObject(msg);
                }
            }

            return View();
        }

        private void SaveOrder(OrderModel model, Payment payment, string userId)
        {
            var order = new Order();
            order.OrderNumber = new Random().Next(111111, 999999).ToString();
            order.OrderState = EnumOrderState.Complated;
            order.PaymentType = EnumPaymentType.CreditCard;
            order.PaymentId = payment.PaymentId;
            order.ConversationId = payment.ConversationId;
            order.OrderDate = new DateTime();
            order.FirstName = model.FirstName;
            order.LastName = model.LastName;
            order.UserId = userId;
            order.Address = model.Address;
            order.Phone = model.Phone;
            order.Email = model.Email;
            order.City = model.City;
            order.Note = model.Note;

            order.OrderItems = new List<OrderItem>();

            foreach (var item in model.CartModel.CartItems)
            {
                var orderItem = new Entities.Concrete.OrderItem()
                {
                    Price = item.Price,
                    Quantity = item.Quantity,
                    ProductId = item.ProductId
                };
                // order.OrderItems= new List<OrderItem>();
                order.OrderItems.Add(orderItem);
            }

            _orderService.Add(order);
        }

        private void ClearCart(int cartId)
        {
            _cartService.ClearCart(cartId);
        }

        private Payment PaymentProcess(OrderModel model)
        {
            Options options = new Options();
            options.ApiKey = "sandbox-xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx";
            options.SecretKey = "sandbox-xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx";
            options.BaseUrl = "https://sandbox-api.iyzipay.com";

            CreatePaymentRequest request = new CreatePaymentRequest();
            request.Locale = Locale.TR.ToString();
            request.ConversationId = new Random().Next(111111111, 999999999).ToString();
            request.Price = model.CartModel.TotalPrice().ToString();
            request.PaidPrice = model.CartModel.TotalPrice().ToString();
            request.Currency = Currency.TRY.ToString();
            request.Installment = 1;
            request.BasketId = "B67832";
            request.PaymentChannel = PaymentChannel.WEB.ToString();
            request.PaymentGroup = PaymentGroup.PRODUCT.ToString();

            PaymentCard paymentCard = new PaymentCard();
            paymentCard.CardHolderName = model.CardName;
            paymentCard.CardNumber = model.CardNumber;
            paymentCard.ExpireMonth = model.ExpirationMonth;
            paymentCard.ExpireYear = model.ExpirationYear;
            paymentCard.Cvc = model.Cvc;
            paymentCard.RegisterCard = 0;
            request.PaymentCard = paymentCard;

            //paymentCard.CardNumber = "5528790000000008";
            //paymentCard.ExpireMonth = "12";
            //paymentCard.ExpireYear = "2030";
            //paymentCard.Cvc = "123";

            Buyer buyer = new Buyer();
            buyer.Id = "BY789";
            buyer.Name = model.FirstName;
            buyer.Surname = model.LastName;
            buyer.GsmNumber = model.Phone;
            buyer.Email = model.Email;
            buyer.IdentityNumber = "74300864791";
            buyer.LastLoginDate = "2015-10-05 12:43:35";
            buyer.RegistrationDate = "2013-04-21 15:12:09";
            buyer.RegistrationAddress = model.Address;
            buyer.Ip = "85.34.78.112";
            buyer.City = model.City;
            buyer.Country = "Turkey";
            buyer.ZipCode = "34732";
            request.Buyer = buyer;

            Address shippingAddress = new Address();
            shippingAddress.ContactName = model.FirstName + " " + model.LastName;
            shippingAddress.City = model.City;
            shippingAddress.Country = "Turkey";
            shippingAddress.Description = model.Address;
            shippingAddress.ZipCode = "34742";
            request.ShippingAddress = shippingAddress;

            Address billingAddress = new Address();
            billingAddress.ContactName = model.FirstName + " " + model.LastName;
            billingAddress.City = model.City;
            billingAddress.Country = "Turkey";
            billingAddress.Description = model.Address;
            billingAddress.ZipCode = "34742";
            request.BillingAddress = billingAddress;

            List<BasketItem> basketItems = new List<BasketItem>();
            BasketItem basketItem;
            foreach (var item in model.CartModel.CartItems)
            {
                basketItem = new BasketItem();
                basketItem.Id = item.ProductId.ToString();
                basketItem.Name = item.Name;
                basketItem.Category1 = "Telefon";
                basketItem.Price = item.Price.ToString();
                basketItem.ItemType = BasketItemType.PHYSICAL.ToString();

                basketItems.Add(basketItem);
            }

            request.BasketItems = basketItems;

            return Payment.Create(request, options);

        }


        public IActionResult Bill()
        {
            var userName = _userManager.FindByNameAsync(_userManager.GetUserName(User)).Result.FirstName + " " + _userManager.FindByNameAsync(_userManager.GetUserName(User)).Result.LastName;
            ViewBag.userName = userName;

            var userEmail = _userManager.FindByNameAsync(_userManager.GetUserName(User)).Result.Email;
            ViewBag.userEmail = userEmail;

            var userPhone = _userManager.FindByNameAsync(_userManager.GetUserName(User)).Result.PhoneNumber;
            ViewBag.userPhone = userPhone;

            var userCity = _userManager.FindByNameAsync(_userManager.GetUserName(User)).Result.City;
            ViewBag.userCity = userCity;

            var cart = _cartService.GetCartByUserId(_userManager.GetUserId(User)).Data;
            return View(new CartModel()
            {
                CartId = cart.Id,
                CartItems = cart.CartItems.Select(i => new CartItemModel()
                {
                    CartItemId = i.Id,
                    ProductId = i.ProductId,
                    Name = i.Product.Name,
                    Price = (double)i.Product.Price,
                    ImageUrl = i.Product.ImageUrl,
                    Quantity = i.Quantity

                }).ToList()
            });
        }


        public IActionResult BillPrint()
        {
            var userName = _userManager.FindByNameAsync(_userManager.GetUserName(User)).Result.FirstName + " " + _userManager.FindByNameAsync(_userManager.GetUserName(User)).Result.LastName;
            ViewBag.userName = userName;

            var userEmail = _userManager.FindByNameAsync(_userManager.GetUserName(User)).Result.Email;
            ViewBag.userEmail = userEmail;

            var userPhone = _userManager.FindByNameAsync(_userManager.GetUserName(User)).Result.PhoneNumber;
            ViewBag.userPhone = userPhone;

            var userCity = _userManager.FindByNameAsync(_userManager.GetUserName(User)).Result.City;
            ViewBag.userCity = userCity;

            var cart = _cartService.GetCartByUserId(_userManager.GetUserId(User)).Data;
            return View(new CartModel()
            {
                CartId = cart.Id,
                CartItems = cart.CartItems.Select(i => new CartItemModel()
                {
                    CartItemId = i.Id,
                    ProductId = i.ProductId,
                    Name = i.Product.Name,
                    Price = (double)i.Product.Price,
                    ImageUrl = i.Product.ImageUrl,
                    Quantity = i.Quantity

                }).ToList()
            });
        }
    }
}
