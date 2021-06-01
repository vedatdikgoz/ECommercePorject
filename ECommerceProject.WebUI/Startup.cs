using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceProject.Core.DependencyResolvers;
using ECommerceProject.Core.Extensions;
using ECommerceProject.Core.Utilities.IoC;
using ECommerceProject.WebUI.CustomValidations;
using ECommerceProject.WebUI.Identity;
using ECommerceProject.WebUI.Middlewares;
using ECommerceProject.WebUI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ECommerceProject.WebUI
{
    public class Startup
    {
        public IConfiguration configuration { get; }
        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddControllersWithViews();
            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer("server=VEDAT; Database=ECommerceDb; Trusted_Connection=true; MultipleActiveResultSets=true"));


            services.AddDependencyResolvers(new ICoreModule[] {
                new CoreModule()
            });


            services.AddIdentity<User, IdentityRole>().AddPasswordValidator<CustomPasswordValidator>()
                .AddUserValidator<CustomUserValidator>().AddEntityFrameworkStores<ApplicationContext>()
                .AddErrorDescriber<CustomIdentityErrorDescriber>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 5;
                options.Password.RequireNonAlphanumeric = false;

                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.AllowedForNewUsers = true;

                options.User.AllowedUserNameCharacters = "abcçdefgðhýijklmnoöprsþtuüvyzABCÇDEFGÐHIÝJKLMNOÖPRSÞTUÜVYZ0123456789-._";

                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedEmail = true;
                options.SignIn.RequireConfirmedPhoneNumber = false;

            });

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Account/Login";
                options.LogoutPath = "/Account/Logout";
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.SlidingExpiration = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                options.Cookie = new CookieBuilder
                {
                    HttpOnly = true,
                    Name = ".ShopApp.Security.Cookie",
                    SameSite = SameSiteMode.Strict
                };

            });


            services.AddScoped<IEmailService, EmailSender>(i =>
                new EmailSender(
                    configuration["EmailSender:Host"],
                    configuration.GetValue<int>("EmailSender:Port"),
                    configuration.GetValue<bool>("EmailSender:EnableSSL"),
                    configuration["EmailSender:UserName"],
                    configuration["EmailSender:Password"])
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IConfiguration config, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseNodeModules(env.ContentRootPath);


            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "orders",
                    pattern: "orders",
                    defaults: new { controller = "Order", action = "GetOrders" }
                );

                endpoints.MapControllerRoute(
                    name: "billprint",
                    pattern: "billprint",
                    defaults: new { controller = "Cart", action = "BillPrint" }
                );

                endpoints.MapControllerRoute(
                    name: "checkout",
                    pattern: "checkout",
                    defaults: new { controller = "Cart", action = "Checkout" }
                );


                endpoints.MapControllerRoute(
                    name: "cart",
                    pattern: "cart",
                    defaults: new { controller = "Cart", action = "Index" }
                );



                endpoints.MapControllerRoute(
                    name: "administrator",
                    pattern: "admin",
                    defaults: new { controller = "Admin", action = "Index" }
                );
                endpoints.MapControllerRoute(
                    name: "statistic",
                    pattern: "statistic",
                    defaults: new { controller = "Statistic", action = "Index" }
                );


                endpoints.MapControllerRoute(
                    name: "adminProducts",
                    pattern: "admin/products",
                    defaults: new { controller = "Admin", action = "ProductList" }
                );

                endpoints.MapControllerRoute(
                    name: "adminProductAdd",
                    pattern: "admin/products/add",
                    defaults: new { controller = "Admin", action = "ProductAdd" }
                );
                endpoints.MapControllerRoute(
                    name: "adminProductUpdate",
                    pattern: "admin/products/{id?}",
                    defaults: new { controller = "Admin", action = "ProductUpdate" }
                );

                endpoints.MapControllerRoute(
                    name: "adminCategories",
                    pattern: "admin/categories",
                    defaults: new { controller = "Admin", action = "CategoryList" }
                );

                endpoints.MapControllerRoute(
                    name: "adminCategoryAdd",
                    pattern: "admin/categories/add",
                    defaults: new { controller = "Admin", action = "CategoryAdd" }
                );
                endpoints.MapControllerRoute(
                    name: "adminCategoryUpdate",
                    pattern: "admin/categories/{id?}",
                    defaults: new { controller = "Admin", action = "CategoryUpdate" }
                );



                endpoints.MapControllerRoute(
                    name: "search",
                    pattern: "search",
                    defaults: new { controller = "Shop", action = "Search" }
                );


                endpoints.MapControllerRoute(
                    name: "productDetails",
                    pattern: "{url}",
                    defaults: new { controller = "Shop", action = "Details" }
                );


                endpoints.MapControllerRoute(
                    name: "products",
                    pattern: "products/{category?}",
                    defaults: new { controller = "Shop", action = "Index" }
                             );


                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            SeedIdentity.Seed(userManager, roleManager, config).Wait();
        }
    }
    
}
