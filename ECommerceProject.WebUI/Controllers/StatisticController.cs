using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceProject.Business.Abstract;

namespace ECommerceProject.WebUI.Controllers
{
    public class StatisticController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IOrderService _orderService;
        public StatisticController(IProductService productService, ICategoryService categoryService, IOrderService orderService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _orderService = orderService;
        }

        
        public IActionResult Index()
        {
            var products = _productService.CountProduct().Data;
            ViewBag.ProductCount = products;

            var categories = _categoryService.CountCategory().Data;
            ViewBag.CategoryCount = categories;

            var maxPrice = _productService.MaxPriceProduct().Data;
            ViewBag.ProductMaxPrice = maxPrice;

            var minPrice = _productService.MinPriceProduct().Data;
            ViewBag.ProductMinPrice = minPrice;

            var maxStock = _productService.MaxStockProduct().Data;
            ViewBag.ProductMaxStock = maxStock;

            var orders = _orderService.CountOrder().Data;
            ViewBag.OrderCount = orders;

            return View();
        }
    }
}
