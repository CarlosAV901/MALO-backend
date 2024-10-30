using MALO.Microservice.Empleos.Infraestructure.Settings;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Mail;

namespace MALO.Microservice.Empleos.Infraestructure.Services
{
    public class EmailService : IMessage
    {
        public GmailSettings _gmailSettings { get; }
        public EmailService(IOptions<GmailSettings> gmailSettings)
        {
            _gmailSettings = gmailSettings.Value;
        }

        public async Task SendEmail(string toEmail, Guid token)
        {
            try
            {
                var fromEmail = _gmailSettings.Username;
                var password = _gmailSettings.Password;
                var verificationLink = $"https://malo-backend.onrender.com/api/usuario/confirmar?token={token}";


                var message = new MailMessage();
                message.From = new MailAddress(fromEmail);
                message.Subject = "Confirma tu correo electrónico";
                message.To.Add(new MailAddress(toEmail));
                message.Body = $@"
                    <!DOCTYPE html>
                    <html lang='es'>
                    <head>
                        <meta charset='UTF-8'>
                        <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                        <title>Confirmación de Correo</title>
                        <style>
                            body {{
                                font-family: Arial, sans-serif;
                                background-color: #f4f4f4;
                                margin: 0;
                                padding: 20px;
                            }}
                            .container {{
                                max-width: 600px;
                                margin: auto;
                                background: white;
                                padding: 20px;
                                border-radius: 5px;
                                box-shadow: 0 2px 5px rgba(0,0,0,0.1);
                            }}
                            .header {{
                                text-align: center;
                                margin-bottom: 20px;
                            }}
                            .header img {{
                                max-width: 100%;
                                height: auto;
                            }}
                            .content {{
                                margin: 20px 0;
                                text-align: center;
                            }}
                            .button {{
                                display: inline-block;
                                padding: 10px 20px;
                                background-color: #007BFF;
                                color: white;
                                text-decoration: none;
                                border-radius: 5px;
                                margin-top: 20px;
                            }}
                            .footer {{
                                text-align: center;
                                font-size: 12px;
                                color: #666;
                                margin-top: 30px;
                            }}
                        </style>
                    </head>
                    <body>
                        <div class='container'>
                            <div class='header'>
                                <img src='https://malo-zeta.vercel.app/malo_logo_azul.png' alt='Logo' />
                            </div>
                            <div class='content'>
                                <h2>¡Gracias por registrarte!</h2>
                                <p>Haz clic en el siguiente enlace para confirmar tu cuenta:</p>
                                <a href='{verificationLink}' class='button'>Confirmar mi cuenta</a>
                            </div>
                            <div class='footer'>
                                <p>Si no te registraste en nuestro sitio, ignora este mensaje.</p>
                            </div>
                        </div>
                    </body>
                    </html>
                    ";
                message.IsBodyHtml = true;

                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = _gmailSettings.Port,
                    Credentials = new NetworkCredential(fromEmail, password),
                    EnableSsl = true
                };

                smtpClient.Send(message);

            }catch (Exception ex)
            {
                throw new Exception("No se pudo enviar el email", ex);
            }
        }
    }
}
