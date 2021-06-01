using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceProject.Business.Abstract;
using ECommerceProject.Entities.Concrete;
using ECommerceProject.WebUI.Models;
using Shopapp.WebUI.Models;

namespace ECommerceProject.WebUI.Controllers
{
    public class ShopController : Controller
    {
        private readonly IProductService _productService;
        public ShopController(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Index(string category,int page=1)
        {
            const int pageSize = 3;
            var productListViewModel = new ProductListViewModel()
            {
                PageInfo = new PageInfo()
                {
                    TotalItems = _productService.GetCountByCategory(category).Data,
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    CurrentCategory = category
                },
                Products = _productService.GetProductsByCategory(category, page, pageSize).Data
            };
            return View(productListViewModel);

        }

        public IActionResult Details(string url)
        {
            if (url == null)
            {
                return NotFound();
            }

            Product product = _productService.GetProductDetails(url).Data;

            if (product==null)
            {
                return NotFound();
            }

            return View(new ProductDetailModel
            {
                Product = product,
                Categories = product.ProductCategories.Select(I=>I.Category).ToList()
            });
        }


        public IActionResult Search(string q)
        {
            var productListViewModel = new ProductListViewModel()
            {

                Products = _productService.GetSearchResult(q).Data
            };
            return View(productListViewModel);
            
        }
    }
}
