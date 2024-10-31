using MALO.Microservice.Empleos.Domain.DTOs.Recuperacion;
using MALO.Microservice.Empleos.Domain.DTOs.Usuario;
using MALO.Microservice.Empleos.Infraestructure.Services;

namespace MALO.Microservice.Empleos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecuperacionController : ApiController
    {
        private readonly IMessage _emailService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="appController"></param>
        public RecuperacionController(IApiController appController, IMessage emailService) : base(appController)
        {
            _emailService = emailService;
        }

        [HttpPost("solicitar-recuperacion")]
        public async Task<IActionResult> SolicitarRecuperacion([FromBody] RecuperacionDTO request)
        {
            var resulatdo = await _appController.RecuperacionPresenter.GenerarTokenRecuperacion(request.Email);

            if(resulatdo == null)
            {
                return BadRequest("Error al solicitar la recuperacion");
            }

            var verificationLink = $"https://malo-backend.onrender.com/api/recuperacion/verificar-token?token={resulatdo}";
            //var verificationLink = $"https://localhost:7181/api/recuperacion/verificar-token?token={resulatdo}";
            var subject = "Confirmación de Cambio de Contraseña";
            var body = $@"
                    <!DOCTYPE html>
                        <html lang=""es"">
                        <head>
                          <meta charset=""UTF-8"">
                          <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
                          <title>Verificación   
                         de Cambio de Contraseña</title>
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
                              background-color: #fff;
                              padding: 20px;
                              border-radius:   
                         5px;
                              box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1);
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

                            .content h2 {{
                              font-size: 20px;
                              margin-bottom: 10px;
                            }}

                            .content p {{
                              line-height: 1.5;
                            }}

                            .button {{
                              display: inline-block;
                              padding: 10px 20px;
                              background-color: #007bff;
                              color: white;
                              text-decoration: none;
                              border-radius:   
                         5px;
                              margin-top: 20px;
                              font-size: 16px;
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
                          <div class=""container"">
                            <div class=""header"">
                              <img src='https://malo-zeta.vercel.app/malo_logo_azul.png' alt=""Your Company Logo"" /> </div>
                            <div class=""content"">
                              <h2>Hemos recibido una solicitud de cambio de contraseña para tu cuenta.</h2>
                              <p>Para confirmar el cambio, haz clic en el siguiente enlace:</p>
                              <a href='{verificationLink}' class=""button"">Confirmar Cambio de Contraseña</a>
                              <p>Si no solicitaste un cambio de contraseña, ignora este mensaje. Tu contraseña actual permanecerá sin cambios.</p>
                            </div>
                            <div class=""footer"">
                              <p>Atentamente,</p>
                              <p>El equipo de {{yourCompanyName}}</p> </div>
                          </div>
                        </body>
                        </html>";


            await _emailService.SendEmail(request.Email, subject, body);

            return Ok(resulatdo); 
        }

        [HttpGet("verificar-token")]
        public async Task<IActionResult> VerificarToken([FromQuery] Guid token)
        {
            bool esValido = await _appController.RecuperacionPresenter.VerificarToken(token);

            if (esValido)
            {
                return Ok(new
                {
                    message = "Token valido, puede continuar",
                    result = true,
                    token_validado = token
                });
            }
            else
            {
                return BadRequest("El token no es valido o ha expirado");
            }
        }

        [HttpPost("cambiar-contrasena")]
        public async Task<IActionResult> ActualizarContrasena([FromBody] CambioContrasenaDTO request)
        {
            var resultado = await _appController.RecuperacionPresenter.ActualizarContrasena(request.token, request.nuevaContrasena);

            if(resultado == null)
            {
                return BadRequest("No se pudo cambiar la contraseña");
            }
            return Ok(new
            {
                message = "Contraseña cambiada correctamente",
                result = true
            });
        }
    }
}
