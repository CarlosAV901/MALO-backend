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

            var verificationLink = $"https://malo-zeta.vercel.app/auth/forgot-password/cambiar-contrasena?token={resulatdo}";
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


        [HttpPost("cambiar-contrasena/{token}")]
        public async Task<IActionResult> ActualizarContrasena([FromRoute] Guid token, [FromBody] CambioContrasenaDTO request)
        {
            // Validar que la nueva contraseña no esté vacía ni sea nula
            if (string.IsNullOrWhiteSpace(request.nuevaContrasena))
            {
                return BadRequest(new { message = "La nueva contraseña es obligatoria", result = false });
            }

            try
            {
                // Llamar al método de infraestructura y obtener el mensaje y código de error
                var (mensajeResultado, codigoError) = await _appController.RecuperacionPresenter.ActualizarContrasena(token, request.nuevaContrasena);

                // Verificar el código de error y retornar la respuesta adecuada
                switch (codigoError)
                {
                    case 0: // Contraseña actualizada correctamente
                        return Ok(new { message = mensajeResultado, result = true });

                    case 1: // Token inválido o no encontrado
                        return NotFound(new { message = mensajeResultado, result = false });

                    case 2: // Token expirado
                        return BadRequest(new { message = mensajeResultado, result = false });

                    case 3: // Error en el procedimiento
                        return StatusCode(500, new { message = mensajeResultado, result = false });

                    default: // Error no esperado
                        return StatusCode(500, new { message = "Error inesperado al cambiar la contraseña", result = false });
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores en la llamada a la infraestructura
                return StatusCode(500, new { message = "Error interno del servidor: " + ex.Message, result = false });
            }
        }


    }
}
