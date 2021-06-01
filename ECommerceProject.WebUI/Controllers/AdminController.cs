using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ECommerceProject.Business.Abstract;
using ECommerceProject.Entities.Concrete;
using ECommerceProject.WebUI.Identity;
using ECommerceProject.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Shopapp.WebUI.Models;

namespace ECommerceProject.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController :Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;
        public AdminController(IProductService productService, ICategoryService categoryService, RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            _productService = productService;
            _categoryService = categoryService;
            _roleManager = roleManager;
            _userManager = userManager;
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
            
            return View();
        }


        public IActionResult Users()
        {
            return View(_userManager.Users.ToList());
            
        }


        public IActionResult RoleCreate()
        {
           // return View();
           return RedirectToAction("Roles");
        }


        [HttpPost]
        public async Task<IActionResult> RoleCreate(RoleViewModel model)
        {

            if (ModelState.IsValid)
            {
                var role = new IdentityRole
                {
                    Name = model.Name
                };
                var result = await _roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("Roles", "Admin");
                }
                else
                {
                    AddModelError(result);
                }

            }
            return View("Roles",model);
        }


        public IActionResult Roles()
        {
            var roles = _roleManager.Roles.ToList();
            ViewBag.Roles = roles;
            return View();
        }


        public async Task<IActionResult> RoleDelete(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role!=null)
            {
               var result = await _roleManager.DeleteAsync(role);
               if (result.Succeeded)
               {
                   return RedirectToAction("Roles");
               }
            }
            
            return RedirectToAction("Roles");
        }


        [HttpGet]
        public async Task<IActionResult> RoleUpdate(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role==null)
            {
                return RedirectToAction("Roles");
            }
            var roleUpdate = new RoleViewModel
            {
                Id = role.Id,
                Name = role.Name

            };
            
            return View(roleUpdate);
        }


        [HttpPost]
        public async Task<IActionResult> RoleUpdate(RoleViewModel model)
        {
            var role = await _roleManager.FindByIdAsync(model.Id);
            if (role!=null)
            {
                role.Name = model.Name;
                var result = await _roleManager.UpdateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("Roles");
                }
                else
                {
                    AddModelError(result);
                }
            }
            else
            {
                ModelState.AddModelError("","Güncelleme başarısız oldu");
            }

            return View(model);
        }




        public IActionResult ProductList()
        {
            var result = _productService.GetAll();
            if (result.Success)
            {
                return View(new ProductListViewModel()
                {
                    Products = result.Data
                });
            }

            return View();
        }

        public IActionResult CategoryList()
        {

            //return View(new CategoryListViewModel()
            //{
            //    Categories = _categoryService.GetAll()
            //});
            var categories = _categoryService.GetAll().Data;
            ViewBag.Categories = categories;
            return View();

        }



        [HttpGet]
        public IActionResult ProductAdd()
        {
           
            return View();

        }

        [HttpPost]
        public IActionResult ProductAdd(ProductAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                var product = new Product()
                {
                    Name = model.Name,
                    Url = model.Url,
                    Price = model.Price,
                    Description = model.Description,
                    ImageUrl = model.ImageUrl,
                    Stock=model.Stock,
                    Brand=model.Brand
                };
                if (_productService.Add(product).Success)
                {
                    return RedirectToAction("ProductList");
                }
                return View(model);
            }

            return View(model);


        }


        [HttpGet]
        public IActionResult CategoryAdd()
        {
           
            return RedirectToAction();

        }

        [HttpPost]
        public IActionResult CategoryAdd(CategoryAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                var category = new Category
                {
                    Name = model.Name,
                    Url = model.Url,
                };
                _categoryService.Add(category);

                return RedirectToAction("CategoryList");
              
            }

            return RedirectToAction("CategoryList");
        }




        [HttpGet]
        public IActionResult ProductUpdate(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var product = _productService.GetByIdWithCategories((int)id).Data;
            if (product == null)
            {
                return NotFound();
            }
            var model = new ProductAddViewModel()
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Url = product.Url,
                Price = product.Price,
                ImageUrl = product.ImageUrl,
                Description = product.Description,
                IsApproved = product.IsApproved,
                IsHome = product.IsHome,
                Stock = product.Stock,
                Brand = product.Brand,
                SelectedCategories = product.ProductCategories.Select(I => I.Category).ToList()
            };

            ViewBag.Categories = _categoryService.GetAll().Data;

            return View(model);

        }


    

        [HttpPost]
        public async Task<IActionResult> ProductUpdate(ProductAddViewModel model, int[] categoryIds,IFormFile file)
        {
            if (ModelState.IsValid)
            {
                var product = _productService.GetById(model.ProductId).Data;
                if (product == null)
                {
                    return NotFound();
                }

                product.Name = model.Name;
                product.Url = model.Url;
                product.Price = model.Price;
                product.Description = model.Description;
                product.IsApproved = model.IsApproved;
                product.IsHome = model.IsHome;
                product.Stock = model.Stock;
                product.Brand = model.Brand;

                if (file != null)
                {
                    product.ImageUrl = file.FileName;
                    var newName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                    product.ImageUrl = newName;
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/", newName);
                    var stream = new FileStream(path, FileMode.Create);
                    await file.CopyToAsync(stream);
                }

                
                if (_productService.Update(product, categoryIds).Data)
                {
                    return RedirectToAction("ProductList");
                }

            }
            ViewBag.Categories = _categoryService.GetAll().Data;
            return View(model);

        }

        [HttpGet]
        public IActionResult CategoryUpdate(int? id)
        {
         
            if (id == null)
            {
                return NotFound();
            }

            var category = _categoryService.GetByIdWithProducts((int)id).Data;
            if (category == null)
            {
                return NotFound();
            }
            var model = new CategoryAddViewModel()
            {
                CategoryId = category.CategoryId,
                Name = category.Name,
                Url = category.Url,
                Products = category.ProductCategories.Select(p=>p.Product).ToList()
                
            };
            return View(model);

        }

        [HttpPost]
        public IActionResult CategoryUpdate(CategoryAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                var category = _categoryService.GetById(model.CategoryId).Data;
                if (category == null)
                {
                    return NotFound();
                }

                category.Name = model.Name;
                category.Url = model.Url;


                _categoryService.Update(category);
                return RedirectToAction("CategoryList");
            }

            return View(model);
        }



        public IActionResult DeleteProduct(int productId)
        {
            var product = _productService.GetById(productId).Data;
            if (product!=null)
            {
                _productService.Delete(product);
            }

            return RedirectToAction("ProductList");
        }


        public IActionResult DeleteCategory(int categoryId)
        {
            var category = _categoryService.GetById(categoryId).Data;
            if (category != null)
            {
                _categoryService.Delete(category);
            }

            return RedirectToAction("CategoryList");
        }


        [HttpPost]
        public IActionResult DeleteFromCategory(int productId, int categoryId)
        {
            _categoryService.DeleteFromCategory(productId, categoryId);
            return Redirect("/admin/categories/"+categoryId);
        }


        [HttpGet]
        public async Task<IActionResult> RoleAssign(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            ViewBag.userName = user.UserName;
            IQueryable<IdentityRole> roles = _roleManager.Roles;
            List<string> userRoles= await _userManager.GetRolesAsync(user) as List<string>;

            var roleAssign=new List<RoleAssignViewModel>();

            foreach (var role in roles)
            {
                var r=new RoleAssignViewModel();

                r.RoleId = role.Id;
                r.RoleName = role.Name;
                if (userRoles.Contains(role.Name))
                {
                    r.Exist = true;
                }
                else
                {
                    r.Exist = false;
                }

                roleAssign.Add(r);
            }

            return View(roleAssign);
        }


        [HttpPost]
        public async Task<IActionResult> RoleAssign(List<RoleAssignViewModel> models, string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            foreach (var item in models)
            {
                if (item.Exist)
                {
                    await _userManager.AddToRoleAsync(user, item.RoleName);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, item.RoleName);
                }
            }

            return RedirectToAction("Users");
        }


        public IActionResult Calendar()
        {
            return View();
        }

        public async Task<IActionResult> ResetUserPassword(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            UserPasswordResetByAdminModel resetByAdminModel = new UserPasswordResetByAdminModel();
            resetByAdminModel.UserId = user.Id;

            return View(resetByAdminModel);
        }

        [HttpPost]
        public async Task<IActionResult> ResetUserPassword(UserPasswordResetByAdminModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
            string token = await _userManager.GeneratePasswordResetTokenAsync(user);
            await _userManager.ResetPasswordAsync(user, token, model.NewPassword);

            await _userManager.UpdateSecurityStampAsync(user);
            

            return RedirectToAction("Users");
        }


    }
}
