using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ECommerceProject.Business.Abstract;
using ECommerceProject.WebUI.Identity;
using ECommerceProject.WebUI.Models;
using ECommerceProject.WebUI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;


namespace ECommerceProject.WebUI.Controllers
{
   
    [AutoValidateAntiforgeryToken]
    public class AccountController :Controller 
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IEmailService _emailService;
        private readonly ICartService _cartService;


        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IEmailService emailService, ICartService cartService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailService = emailService;
            _cartService = cartService;
        }

        public void AddModelError(IdentityResult result)
        {

            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("", item.Description);
            }
        }

        public IActionResult Login(string returnUrl = null)
        {
            return View(new LoginViewModel()
            {
                ReturnUrl = returnUrl
            });
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {

            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);

                if (user != null)
                {
                    if (!await _userManager.IsEmailConfirmedAsync(user))
                    {
                        ModelState.AddModelError("", "Email hesabınıza gelen üyelik linkini onaylayınız");
                        return View(model);
                    }
                    if (await _userManager.IsLockedOutAsync(user))
                    {
                        ModelState.AddModelError("", "Hesabınız bir süreliğine kilitlendi");
                        return View(model);
                    }


                    await _signInManager.SignOutAsync();

                    var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);

                    if (result.Succeeded)
                    {
                        await _userManager.ResetAccessFailedCountAsync(user);

                        return Redirect(model.ReturnUrl ?? "~/");
                    }
                    else
                    {
                        await _userManager.AccessFailedAsync(user);
                        int fail = await _userManager.GetAccessFailedCountAsync(user);
                        if (fail == 3)
                        {
                            await _userManager.SetLockoutEndDateAsync(user, new DateTimeOffset(DateTime.Now.AddMinutes(20)));
                            ModelState.AddModelError("", "3 başarısız giriş. Hesabınız 20 dakika süreyle bloke edilmiştir");

                        }
                        else
                        {
                            ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı");
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Bu email adresine kayıtlı kullanıcı bulunamadı");
                }

            }

            return View(model);
        }



        public IActionResult Register()
        {
            return View();
        }

        [HttpPost] 
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User();
                user.FirstName = model.FirstName;
                user.LastName = model.FirstName;
                user.UserName = model.UserName;
                user.Email = model.Email;
                user.PhoneNumber = model.PhoneNumber;

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var url = Url.Action("ConfirmEmail", "Account", new
                    {
                        userId = user.Id,
                        token = code
                    });

                    await _emailService.SendEmailAsync(model.Email, "Hesabınızı onaylayınız.", $"<a href='https://localhost:44395{url}'>Hesabınızı onaylamak için linke tıklayınız</a>");

                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    AddModelError(result);
                    return View(model);
                }
            }


            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Redirect("~/");
        }


        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (userId == null || token == null)
            {
                return View();
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var result = await _userManager.ConfirmEmailAsync(user, token);
                if (result.Succeeded)
                {
                    _cartService.InitializeCart(user.Id);
                    await _userManager.AddToRoleAsync(user, "Member");
                    return View();
                }

            }
            return View();

        }

        
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                ModelState.AddModelError("", "Geçerli bir email adresi giriniz");
                return View();
            }

            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                ModelState.AddModelError("", "Sistemde kayıtlı email adresi bulunamadı");
                return View();
            }

            var code = await _userManager.GeneratePasswordResetTokenAsync(user);
            var url = Url.Action("ResetPassword", "Account", new
            {
                userId = user.Id,
                token = code
            });

            await _emailService.SendEmailAsync(email, "Şifre değiştirme", $"<a href='https://localhost:44395{url}'>Şifrenizi değiştirmek için linke tıklayınız</a>");

            return View();
        }

        //[Authorize]
        [HttpGet]
        public IActionResult ResetPassword(string userId, string token)
        {
            if (userId == null || token == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var model = new ResetPasswordModel { Token = token };
            return View();
        }

        //[Authorize]
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
            if (result.Succeeded)
            {
                await _userManager.UpdateSecurityStampAsync(user);               
                return RedirectToAction("Login", "Account");
            }
            return View(model);
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Manager()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var userViewModel = new UserViewModel();
            userViewModel.UserName = user.UserName;
            userViewModel.FirstName = user.FirstName;
            userViewModel.LastName = user.LastName;
            userViewModel.Email = user.Email;
            userViewModel.PhoneNumber = user.PhoneNumber;
            userViewModel.City = user.City;
            userViewModel.BirthDay = user.BirthDay;
            userViewModel.Picture = user.Picture;


            return View(userViewModel);
        }

        [Authorize]
        public IActionResult PasswordChange()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> PasswordChange(PasswordChangeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                if (user != null)
                {
                    bool exist = await _userManager.CheckPasswordAsync(user, model.PasswordCurrent);

                    if (exist)
                    {
                        var result = await _userManager.ChangePasswordAsync(user, model.PasswordCurrent, model.PasswordNew);

                        if (result.Succeeded)
                        {
                            await _userManager.UpdateSecurityStampAsync(user);

                            await _signInManager.SignOutAsync();

                            await _signInManager.PasswordSignInAsync(user, model.PasswordNew, true, false);


                            ViewBag.success = "true";

                        }
                        else
                        {
                            AddModelError(result);
                        }
                    }
                    ModelState.AddModelError("", "Mevcut şifrenizi hatalı girdiniz");
                }
            }
            return View(model);
        }



        [Authorize]
        public async Task<IActionResult> UserEdit()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            


            var userEdit = new UserViewModel();
            userEdit.UserName = user.UserName;
            userEdit.FirstName = user.FirstName;
            userEdit.LastName = user.LastName;
            userEdit.Email = user.Email;
            userEdit.PhoneNumber = user.PhoneNumber;
            userEdit.City = user.City;
            userEdit.BirthDay = user.BirthDay;
            userEdit.Picture = user.Picture;
           

            return View("Manager",userEdit);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> UserEdit(UserViewModel model,IFormFile userPicture)
        {           

            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                

                if (userPicture != null && userPicture.Length>0)
                {
                    var newName = Guid.NewGuid() + Path.GetExtension(userPicture.FileName);
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/userimg/", newName);
                    var stream = new FileStream(path, FileMode.Create);
                    await userPicture.CopyToAsync(stream);
                    user.Picture = "/userimg/" + newName;
                }



                user.UserName = model.UserName;
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Email = model.Email;
                user.PhoneNumber = model.PhoneNumber;
                user.City = model.City;
                user.BirthDay = model.BirthDay;
                
                


                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    await _userManager.UpdateSecurityStampAsync(user);

                    await _signInManager.SignOutAsync();

                    await _signInManager.SignInAsync(user, true);

                    ViewBag.success = "true";

                    return RedirectToAction("Manager");
                }
                else
                {
                    AddModelError(result);
                }
            }

            return RedirectToAction("Manager");
        }


        public IActionResult LoginFacebook(string returnUrl)
        {
            string redirectUrl = Url.Action("ExternalResponse", "Account",new{ ReturnUrl = returnUrl});
            var properties= _signInManager.ConfigureExternalAuthenticationProperties("Facebook", redirectUrl);

            return new ChallengeResult("Facebook",properties);

        }

        public IActionResult LoginGoogle(string returnUrl)
        {
            string redirectUrl = Url.Action("ExternalResponse", "Account", new { ReturnUrl = returnUrl });
            var properties = _signInManager.ConfigureExternalAuthenticationProperties("Google", redirectUrl);

            return new ChallengeResult("Google", properties);

        }

        public IActionResult LoginMicrosoft(string returnUrl)
        {
            string redirectUrl = Url.Action("ExternalResponse", "Account", new { ReturnUrl = returnUrl });
            var properties = _signInManager.ConfigureExternalAuthenticationProperties("Microsoft", redirectUrl);

            return new ChallengeResult("Microsoft", properties);

        }

        public async Task<IActionResult> ExternalResponse(string returnUrl="/")
        {
            ExternalLoginInfo info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                var result=await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey,true);

                if (result.Succeeded)
                {
                    return RedirectToAction(returnUrl);
                }
                else
                {
                    var user=new User();
                    user.Email = info.Principal.FindFirst(ClaimTypes.Email).Value;
                    string externalUserId = info.Principal.FindFirst(ClaimTypes.NameIdentifier).Value;

                    if (info.Principal.HasClaim(x=>x.Type==ClaimTypes.Name))
                    {
                        string userName = info.Principal.FindFirst(ClaimTypes.Name).Value;
                        userName = userName.Replace(' ', '-').ToLower() + externalUserId.Substring(0, 5).ToString();

                        user.UserName = userName;
                    }
                    else
                    {
                        user.UserName = info.Principal.FindFirst(ClaimTypes.Email).Value;
                    }

                    User user2 = await _userManager.FindByEmailAsync(user.Email);
                    if (user2==null)
                    {
                        var createResult = await _userManager.CreateAsync(user);

                        if (createResult.Succeeded)
                        {
                            var loginResult = await _userManager.AddLoginAsync(user, info);
                            if (loginResult.Succeeded)
                            {
                                //await _signInManager.SignInAsync(user, true);
                                await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, true);
                                await _userManager.AddToRoleAsync(user, "Member");
                                return Redirect(returnUrl);
                            }
                            else
                            {
                                AddModelError(loginResult);
                            }
                        }
                        else
                        {
                            AddModelError(createResult);
                        }
                    }
                    else
                    {
                        var loginResult = await _userManager.AddLoginAsync(user2, info);
                        await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, true);
                        await _userManager.AddToRoleAsync(user, "Member");
                        return Redirect(returnUrl);
                    }


                }
            }

            List<string> errors = ModelState.Values.SelectMany(x=>x.Errors).Select(y=>y.ErrorMessage).ToList();

            return RedirectToAction("Error",errors);

        }



        public IActionResult Error()
        {
            return View();
        }

                
    }

}