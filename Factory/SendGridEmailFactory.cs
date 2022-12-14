using System.Threading.Tasks;
using AutoServis.Authorization;
using AutoServis.Contracts;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace AutoServis.Factory
{
    public class SendGridEmailFactory : ISendGridEmailFactory
    {
        public SendGridEmailSenderOptions Options { get; set; }

            public SendGridEmailFactory(IOptions<SendGridEmailSenderOptions> options)
            {
                this.Options = options.Value;
            }

            public async Task SendEmailAsync(string email, string subject, string message)
            {
                await Execute(Options.ApiKey, subject, message, email);
            }

            private async Task<Response> Execute(string apiKey, string subject, string message, string email)
            {
                var client = new SendGridClient(apiKey);
                var msg = new SendGridMessage()
                {
                    From = new EmailAddress(Options.SenderEmail, Options.SenderName),
                    Subject = subject,
                    PlainTextContent = message,
                    HtmlContent = message
                };
                //msg.SetTemplateId(Options.RegisterTemplate);
                msg.AddTo(new EmailAddress(email));
                msg.SetClickTracking(false, false);
                msg.SetOpenTracking(false);
                msg.SetGoogleAnalytics(false);
                msg.SetSubscriptionTracking(false);
                var send = await client.SendEmailAsync(msg);
                return send;
            }
    }
}
