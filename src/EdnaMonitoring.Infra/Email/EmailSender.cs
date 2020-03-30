using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace EdnaMonitoring.Infra.Email
{
    public class EmailSender : IEmailSender
    {
        public async Task SendEmailAsync(string emailAddresses, string subject, string htmlMessage)
        {
            await Task.Delay(50);
            Console.WriteLine("Mail sending not possible currently");
        }
    }
}
