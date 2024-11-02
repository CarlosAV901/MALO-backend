using MALO.Microservice.Empresas.Infraestructure.Settings;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Mail;

namespace MALO.Microservice.Empresas.Infraestructure.Services
{
    public class EmailService : IMessage
    {
        public GmailSettings _gmailSettings { get; }
        public EmailService(IOptions<GmailSettings> gmailSettings)
        {
            _gmailSettings = gmailSettings.Value;
        }

        public async Task SendEmail(string toEmail, string subject, string body)
        {
            try
            {
                var fromEmail = _gmailSettings.Username;
                var password = _gmailSettings.Password;



                var message = new MailMessage();
                message.From = new MailAddress(fromEmail);
                message.Subject = subject;
                message.To.Add(new MailAddress(toEmail));
                message.Body = body;
                message.IsBodyHtml = true;

                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = _gmailSettings.Port,
                    Credentials = new NetworkCredential(fromEmail, password),
                    EnableSsl = true
                };

                smtpClient.Send(message);

            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo enviar el email", ex);
            }
        }
    }
}
