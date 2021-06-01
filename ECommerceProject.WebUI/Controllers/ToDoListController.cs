using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceProject.WebUI.Controllers
{
    public class ToDoListController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
