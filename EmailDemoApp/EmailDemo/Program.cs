using Emails;
using FluentEmail.Core;
using FluentEmail.Razor;
using FluentEmail.Smtp;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EmailDemo
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            await SendWithPickupDirectory();
            //await SendWithNetwork();
            //await SendWithTemplate();
        }

        public static async Task SendWithTemplate()
        {
            SmtpSender sender = GetSender();

            Email.DefaultSender = sender;
            Email.DefaultRenderer = new RazorRenderer();

            StringBuilder template = GetTemplate();
            var email = new EmailHelper
            {
                From = "alexei.80@hotmail.fr",
                To = "tekumsee.80@gmail.com",
                Name = "alex",
                Subject = "salut",
                Template = template
            };

            await email.SendEmailWithTemplate("shirley", "vegan food");
        }

        private static SmtpSender GetSender()
        {
            return new SmtpSender(() => new SmtpClient("localhost")
            {
                EnableSsl = false,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Port = 25
            });
        }

        private static StringBuilder GetTemplate()
        {
            StringBuilder template = new StringBuilder();
            template.AppendLine("Dear @Model.FirstName");
            template.AppendLine("<p>Thanks for purchasing @Model.ProductName. Enjoy!</p>");
            template.AppendLine("Alex");
            return template;
        }

        private static async Task SendWithNetwork()
        {
            SmtpSender sender = GetSender();

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

        private static async Task SendWithPickupDirectory()
        {
            SmtpSender sender = GetDirectorySender();

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

        private static SmtpSender GetDirectorySender()
        {
            return new SmtpSender(() => new SmtpClient("localhost")
            {
                EnableSsl = false,
                DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory,
                PickupDirectoryLocation = @"C:\source\CsharpLibraries\SendingEmail_CsharpUsingFluentEmail"
            });
        }
    }
}
