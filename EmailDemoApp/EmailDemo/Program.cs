using Emails;
using FluentEmail.Core;
using FluentEmail.Smtp;
using System.Net.Mail;
using System.Threading.Tasks;

namespace EmailDemo
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var sender = new SmtpSender(() => new SmtpClient("localhost")
            {
                EnableSsl = false,
                DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory,
                PickupDirectoryLocation = @"C:\source\CsharpLibraries\SendingEmail_CsharpUsingFluentEmail"
            });

            Email.DefaultSender = sender;

            var email = new EmailHelper
            {
                From = "alexei.80@hotmail.fr",
                To = "tekumsee.80@gmail.com",
                Name = "alex",
                Subject = "salut",
                Body = "merci de lire ce mail",
            };

            await email.SendEmail();
        }
    }
}
