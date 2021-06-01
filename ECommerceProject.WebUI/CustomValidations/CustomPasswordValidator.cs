using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceProject.WebUI.Identity;
using Microsoft.AspNetCore.Identity;


namespace ECommerceProject.WebUI.CustomValidations
{
    public class CustomPasswordValidator:IPasswordValidator<User>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<User> manager, User user, string password)
        {
            List<IdentityError> errors= new List<IdentityError>();

            if (password.ToLower().Contains(user.UserName.ToLower()))
            {
                if (!user.Email.Contains(user.UserName))
                {
                    errors.Add(new IdentityError() { Code = "PasswordContainsUserName", Description = "Şifre alanı kullanıcı adı içeremez" });
                }
                
            }

            if (password.ToLower().Contains("1234"))
            {
                errors.Add(new IdentityError() { Code = "PasswordContains1234", Description = "Şifre alanı ardışık sayı içeremez" });
            }

            if (password.ToLower().Contains(user.Email.ToLower()))
            {
                errors.Add(new IdentityError() { Code = "PasswordContainsEmail", Description = "Şifre alanı email içeremez" });
            }

            if (errors.Count==0)
            {
                return Task.FromResult(IdentityResult.Success);
            }
            else
            {
                return Task.FromResult(IdentityResult.Failed(errors.ToArray()));
            }
        }
    }
}
