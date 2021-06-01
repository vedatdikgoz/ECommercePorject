using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceProject.WebUI.Identity;
using Microsoft.AspNetCore.Identity;

namespace ECommerceProject.WebUI.CustomValidations
{
    public class CustomUserValidator:IUserValidator<User>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<User> manager, User user)
        {
            List<IdentityError> errors= new List<IdentityError>();

            string[] Digits= new string[]{"0","1","2","3","4","5","6","7","8","9"};

            foreach (var item in Digits)
            {
                if (user.UserName[0].ToString()==item)
                {
                    errors.Add(new IdentityError(){Code = "UserNameContainsFirstLatterDigitContains",Description="Kullanıcı adının ilk harfi rakam içeremez"});
                }
            }

            if (errors.Count == 0)
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
