using FluentEmail.Core;
using FluentEmail.Core.Models;
using System;
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

        public async Task<SendResponse> SendEmail()
        {
            SendResponse email = await Email.From(From)
                                   .To(To, Name)
                                   .Subject(Subject)
                                   .Body(Body)
                                   .SendAsync();

            return email;
        }
    }
}
