using System;
using ECommerceProject.Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;


namespace ECommerceProject.WebUI.ViewComponents
{
    public class CategoryListViewComponent:ViewComponent
    {
        private ICategoryService _categoryService;

        public CategoryListViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            if (RouteData.Values["category"]!=null)
            {
                ViewBag.SelectedCategory = RouteData?.Values["category"];
            }
            return View(_categoryService.GetAll().Data);
        }
    }
}
