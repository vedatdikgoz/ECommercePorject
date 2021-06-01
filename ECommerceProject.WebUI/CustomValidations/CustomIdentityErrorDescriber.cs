using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ECommerceProject.WebUI.CustomValidations
{
    public class CustomIdentityErrorDescriber:IdentityErrorDescriber
    {
        public override IdentityError InvalidUserName(string userName)
        {
            return new IdentityError()
            {
                Code = "InvalidUserName",
                Description = $"{userName} kullanıcı adı geçersizdir."
            };
        }


        public override IdentityError DuplicateUserName(string userName)
        {
            return new IdentityError()
            {
                Code = "DuplicateUserName",
                Description = $"{userName} kullanıcı adı daha önce alınmıştır"
            };
        }

        public override IdentityError DuplicateEmail(string email)
        {
            return new IdentityError()
            {
                Code = "DuplicateEmail",
                Description = $"{email} email adresi daha kullanılmıştır."
            };
        }


        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError()
            {
                Code = "PasswordTooShort",
                Description = $"Şifreniz en az {length} karakter olmalıdır."
            };
        }
    }
}
