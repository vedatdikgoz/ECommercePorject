using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceProject.WebUI.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ECommerceProject.WebUI.TagHelpers
{
    [HtmlTargetElement("td",Attributes = "user-roles")]
    public class UserRoleName:TagHelper
    {
        public UserManager<User> UserManager { get; set; }

        public UserRoleName(UserManager<User> userManager)
        {
            this.UserManager = userManager;
        }

        [HtmlAttributeName("user-roles")]
        public string UserId { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var user = await UserManager.FindByIdAsync(UserId);
            IList<string> roles = await UserManager.GetRolesAsync(user);

            string html = string.Empty;
            roles.ToList().ForEach(x =>
            {
                html += $"<span class='badge badge-info'>{x}</span>";
            });
            output.Content.SetHtmlContent(html);
        }
    }
}
