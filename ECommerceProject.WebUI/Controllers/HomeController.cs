using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceProject.Business.Abstract;
using ECommerceProject.WebUI.Models;

namespace ECommerceProject.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private IProductService _productService;

        public HomeController(IProductService productService)
        {
            _productService = productService;
        }
        
        public IActionResult Index()
        {
            var result = _productService.GetAll();
            if (result.Success)
            {
                var productListViewModel = new ProductListViewModel()
                {
                    Products = result.Data
                };
                return View(productListViewModel);
            }

            return View(result.Message);
        }
    }
}
