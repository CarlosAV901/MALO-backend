

using MALO.Microservice.Empleos.Aplication.Services;
using MALO.Microservice.Empleos.Domain.DTOs.Usuario;
using MALO.Microservice.Empleos.Infraestructure.Services;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;

namespace MALO.Microservice.Empleos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ApiController
    {
        private readonly IMessage _emailService;
        private readonly FileService _fileService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="appController"></param>
        public UsuarioController(IApiController appController, IMessage emailService, FileService fileService) : base(appController)
        {
            _emailService = emailService;
            _fileService = fileService;
        }





        /// <summary>
        /// Consulta un regsitro de la tabla GI_Persona
        /// </summary>
        /// <param name="">Params de entrada</param> 
        /// <remarks>
        /// Sample request: 
        /// 
        ///     POST 
        ///       {
        ///         "User":"SysAdmin"
        ///       }
        /// </remarks>   
        /// <response code="200">string</response>  
        /// <response code="400">string</response> 
        /// <response code="500">string</response> 
        [HttpPost("ObtenerUsuarioPorId")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async ValueTask<IActionResult> ObtenerUsuarioPorId([FromBody] ObtenerUsuarioPorId request)
        {
            var usuario = await _appController.UserPresenter.ObtenerUsuarioPorId(request.Id);

            return Ok(usuario);
        }

        /// <summary>
        /// Consulta un regsitro de la tabla GI_Persona
        /// </summary>
        /// <param name="">Params de entrada</param> 
        /// <remarks>
        /// Sample request: 
        /// 
        ///     POST 
        ///       {
        ///         "User":"SysAdmin"
        ///       }
        /// </remarks>   
        /// <response code="200">string</response>  
        /// <response code="400">string</response> 
        /// <response code="500">string</response> 
        [HttpGet("ObtenerUsuarios")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async ValueTask<IActionResult> ObtenerUsuarios()
        {
            var usuario = await _appController.UserPresenter.ObtenerUsuarios();

            return Ok(usuario);
        }

        /// <summary>
        /// Inserta un nuevo usuario en el sistema.
        /// </summary>
        /// <param name="usuarioInsertarDto">Datos del usuario a insertar</param> 
        /// <remarks>
        /// Sample request: 
        /// 
        ///     POST 
        ///     {
        ///         "Nombre": "Carlos",
        ///         "Apellido": "Aguilar",
        ///         "Email": "charly@example.com",
        ///         "Contrasena": "secreta123",
        ///         "FechaNacimiento": "1990-05-15",
        ///         "Telefono": "555-1234",
        ///         "RolId": 1,
        ///         "EstadoId": 1,
        ///         "MunicipioId": 1,
        ///         "LocalidadId": 1,
        ///         "Habilidades": "1,2",
        ///         "Descripcion": "Trabaje 5 años en una empresa de software",
        ///         "ImagenPerfil": null
        ///     }
        /// </remarks>   
        /// <response code="200">Usuario insertado con éxito</response>  
        /// <response code="400">Error en la solicitud (datos inválidos)</response> 
        /// <response code="500">Error interno del servidor</response>
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpPost("InsertarUsuario")]
        public async ValueTask<IActionResult> InsertarUsuario([FromBody] UsuarioInsertarDto usuarioInsertarDto)
        {

            
            var usuario = await _appController.UserPresenter.InsertarUsuario(usuarioInsertarDto);
            
            if (usuario == null)
            {
                return BadRequest("No se pudo registrar al usuario");
            }

            var verificationLink = $"https://malo-backend.onrender.com/confirmar?token={usuarioInsertarDto.token}";
            //var verificationLink = $"https://localhost:7181/api/usuario/confirmar?token={usuarioInsertarDto.token}";
            var subject = "Confirma tu cuenta";
            var body = $@"
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


            await _emailService.SendEmail(usuarioInsertarDto.email, subject, body);


            return Ok(new
            {
                message = "Usuario registrado. Revisa tu correo para confirmar la cuenta."
            });

        }



        [HttpGet("confirmar")]
        public async Task<IActionResult> ConfirmarCorreo([FromQuery] Guid token)
        {
            
            var (mensajeResultado, codigoError) = await _appController.UserPresenter.ConfirmarUsuario(token);

            switch (codigoError)
            {
                case 0:
                    return Redirect("https://malo-zeta.vercel.app/auth/login");
                case 1: // Contraseña actualizada correctamente
                    return Redirect("https://malo-zeta.vercel.app/auth/cuenta-confirmada");
                case 2: // Token inválido o no encontrado
                    return NotFound(new { message = mensajeResultado, result = false });
                case 3: // Token expirado
                    return NotFound(new { message = mensajeResultado, result = false });
                case 4: // Error en el procedimiento
                    return StatusCode(500, new { message = mensajeResultado, result = false });

                default: // Error no esperado
                    return StatusCode(500, new { message = "Error inesperado", result = false });
            }
  
        }

        [HttpPost("generar-nuevo-token")]
        public async Task<IActionResult> GenerarNuevoToken([FromBody] NuevoTokenDTO request)
        {
            var resulatdo = await _appController.RecuperacionPresenter.GenerarTokenRecuperacion(request.Email);

            if (resulatdo == null)
            {
                return BadRequest("Error al solicitar la recuperacion");
            }

            var generateTokenLink = $"https://malo-backend.onrender.com/api/usuario/confirmar?token={resulatdo}";
            //var verificationLink = $"https://localhost:7181/api/recuperacion/verificar-token?token={resulatdo}";
            var subject = "Confirma tu cuenta";
            var body = $@"
                        <!DOCTYPE html>
                        <html lang=""es"">
                        <head>
                            <meta charset=""UTF-8"">
                            <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
                            <title>Generación de Nuevo Token de Confirmación</title>
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
                            <div class=""container"">
                            <div class=""header"">
                                <img src='https://malo-zeta.vercel.app/malo_logo_azul.png' alt=""Your Company Logo"" />
                            </div>
                            <div class=""content"">
                                <h2>¿Necesitas un nuevo token de confirmación?</h2>
                                <p>Hemos recibido tu solicitud para generar un nuevo token de confirmación.</p>
                                <a href='{generateTokenLink}' class=""button"">Confirmar mi cuenta</a>
                                <p>Si no solicitaste un nuevo token, ignora este mensaje.</p>
                            </div>
                            <div class=""footer"">
                                <p>Atentamente,</p>
                                <p>El equipo de Manos a la Obra</p>
                            </div>
                            </div>
                        </body>
                        </html>";



            await _emailService.SendEmail(request.Email, subject, body);

            return Ok(resulatdo);
        }


        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpPost("EliminarUsuario")]
        [Authorize]
        public async ValueTask<IActionResult> EliminarUsuario([FromBody] ObtenerUsuarioPorId request)
        {
            var usuario = await _appController.UserPresenter.EliminarUsuario(request.Id);

            return Ok(usuario);
        }


        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [HttpPost("ActualizarUsuario")]
        [Authorize]
        public async ValueTask<IActionResult> ActualizarUsuario([FromForm] ActualizarUsuarioDTO request, [FromForm] IFormFile archivo)
        {
            string urlImagen = null;

            var usuarioDto = new ObtenerUsuarioPorId { Id = request.UsuarioId };

            var documento = await _appController.UserPresenter.ObtenerContenido(usuarioDto);
            

            if (!string.IsNullOrEmpty(documento))
            {
                var nombreArchivoAnterior = Path.GetFileName(documento);
                await _fileService.EliminarArchivo(nombreArchivoAnterior);
            }

            if (archivo != null)
            {
                try
                {
                    urlImagen = await _fileService.SubirArchivo(archivo);
                }
                catch (Exception ex)
                {
                    return BadRequest($"Error al subir el archivo: {ex.Message}");
                }
            }

            request.imagen_perfil = urlImagen;

            var usuario = await _appController.UserPresenter.ActualizarUsuario(request.UsuarioId, request);

            return Ok(usuario);
        }


    }
}
