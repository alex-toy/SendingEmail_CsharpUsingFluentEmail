using FluentEmail.Core;
using FluentEmail.Core.Models;
using System.Text;
using System.Threading.Tasks;

namespace Emails
{
    public class EmailHelper
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public StringBuilder Template { get; set; }

        public async Task<SendResponse> SendEmail()
        {
            SendResponse email = await Email.From(From)
                                   .To(To, Name)
                                   .Subject(Subject)
                                   .Body(Body)
                                   .SendAsync();

            return email;
        }

        public async Task<SendResponse> SendEmailWithTemplate(string firstName, string productName)
        {
            SendResponse email = await Email.From(From)
                                           .To(To, Name)
                                           .Subject(Subject)
                                           .UsingTemplate(Template.ToString(), new {
                                               FirstName = firstName,
                                               ProductName = productName
                                           })
                                           .SendAsync();

            return email;
        }
    }
}
