using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace ECommerceProject.WebUI.Identity
{
    public class ApplicationContext:IdentityDbContext<User,IdentityRole,string>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options): base(options)
        {
            
        }
    }
}
