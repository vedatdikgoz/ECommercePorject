using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ECommerceProject.WebUI.Helpers
{
    public static class PasswordReset
    {
        public static void PasswordResetSendEmail(string link)
        {
            MailMessage mail= new MailMessage();
            SmtpClient smtpClient= new SmtpClient();
        }
    }
}
