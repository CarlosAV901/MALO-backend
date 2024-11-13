using MALO.Microservice.Empresas.Infraestructure.Services;


namespace MALO.Microservice.Empresas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpresaController : ApiController
    {
        private readonly IMessage _emailService;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="appController"></param>
        public EmpresaController(IApiControllerEmpresas appController, IMessage emailService) : base(appController)
        {
            _emailService = emailService;
        }
        //Consultar empresas
        /// <summary>
        /// Consulta un registro de la tabla Empresas
        /// </summary>
        /// <remarks>
        /// Sample request: 
        /// 
        ///     GET 
        ///       {
        ///         // No params needed
        ///       }
        /// </remarks>   
        /// <response code="200">Detalles de la empresa</response>  
        /// <response code="400">Solicitud incorrecta</response> 
        /// <response code="500">Error interno del servidor</response> 
        [HttpGet("GetEmpresa")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(EmpresaDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async ValueTask<IActionResult> GetEmpresa()
        {
            var empresa = await _appController.EmpresaPresenter.GetEmpresa();

            if (empresa == null)
            {
                return NotFound("No se encontró la empresa.");
            }

            return Ok(empresa);
        }

        //Consultar empresa 
        [HttpPost("GetEmpresaPorId")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(EmpresaDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async ValueTask<IActionResult> GetEmpresaPorId([FromBody] Guid empresaId)
        {
            if (empresaId == Guid.Empty)
            {
                return BadRequest("El ID de la empresa es requerido.");
            }

            var empresa = await _appController.EmpresaPresenter.GetEmpresaPorId(empresaId);

            if (empresa == null)
            {
                return NotFound("No se encontró la empresa.");
            }

            return Ok(empresa);
        }

        //Agregar empresa empresas
        [HttpPost("agregar-empresa")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AgregarEmpresa([FromBody] InsertarEmpresaDto insertarEmpresaDto)
        {
            if (insertarEmpresaDto == null || string.IsNullOrEmpty(insertarEmpresaDto.nombre))
            {
                return BadRequest("El nombre de la empresa es requerido.");
            }

            var empresa = await _appController.EmpresaPresenter.AddEmpresa(insertarEmpresaDto);

            if(empresa == null)
            {
                return BadRequest("No se pudo registrar la empresa, intenta de nuevo");
            }

            var verificationLink = $"https://malo-backend-empresas.onrender.com/api/empresa/confirmar?token={insertarEmpresaDto.token}";
            //var verificationLink = $"https://localhost:8000/api/empresa/confirmar?token={insertarEmpresaDto.token}";
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
                                <h2>¡Gracias por registrar tu empresa!</h2>
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

            try
            {
                await _emailService.SendEmail(insertarEmpresaDto.email, subject, body);

                return Ok(new
                {
                    message = "Empresa registrada. Revisa tu correo para confirmar la cuenta."
                });
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al agregar la empresa: {ex.Message}");
            }
        }


        [HttpGet("confirmar")]
        public async Task<IActionResult> ConfirmarCorreo([FromQuery] Guid token)
        {
            var (mensajeResultado, codigoError) = await _appController.EmpresaPresenter.ConfirmarEmpresa(token);

            switch (codigoError)
            {
                case 0:
                    return Redirect("https://malo-zeta.vercel.app/auth/login");
                case 1: // Contraseña actualizada correctamente
                    return Redirect("https://malo-zeta.vercel.app/auth/cuenta-confirmada");
                case 2: // Token inválido o no encontrado
                    return NotFound(new { message = mensajeResultado, result = false });
                case 3: // Token expirado
                    return Redirect("https://malo-zeta.vercel.app/auth/expired-token");
                case 4: // Error en el procedimiento
                    return StatusCode(500, new { message = mensajeResultado, result = false });

                default: // Error no esperado
                    return StatusCode(500, new { message = "Error inesperado", result = false });
            }

        }


        [HttpPost("generar-nuevo-token")]
        public async Task<IActionResult> GenerarNuevoToken([FromBody] NuevoTokenDTO request)
        {
            var resulatdo = await _appController.RecuperacionPresenter.GenerarTokenRecuperacion(request.email);

            if (resulatdo == null)
            {
                return BadRequest("Error al solicitar la recuperacion");
            }

            var generateTokenLink = $"https://malo-backend-empresas.onrender.com/api/empresa/confirmar?token={resulatdo}";
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
                                <img src='https://malo-zeta.vercel.app/malo_logo_azul.png' alt=""Malo logo"" />
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



            await _emailService.SendEmail(request.email, subject, body);

            return Ok(resulatdo);
        }


        //actualizar empresa
        [HttpPost("actualizar-empresa")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ActualizarEmpresa([FromBody] ActualizarEmpresaDto empresaDto)
        {
            if (empresaDto == null || string.IsNullOrEmpty(empresaDto.Id))
            {
                return BadRequest("El ID y los detalles de la empresa son requeridos.");
            }

            try
            {
                var resultado = await _appController.EmpresaPresenter.UpdateEmpresa(empresaDto);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al actualizar la empresa: {ex.Message}");
            }
        }

        //eliminar empresa
        /// <summary>
        /// Elimina un registro de la tabla Empresas
        /// </summary>
        /// <param name="empresaDto">DTO con los datos de la empresa a eliminar</param>
        /// <returns>Resultado de la eliminación</returns>
        [HttpPost("eliminar-empresa")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> EliminarEmpresa([FromBody] EliminarEmpresaDto empresaDto)
        {
            if (empresaDto == null || string.IsNullOrEmpty(empresaDto.Id) || !Guid.TryParse(empresaDto.Id, out var empresaId))
            {
                return BadRequest("El ID de la empresa es requerido o no es válido.");
            }

            try
            {
                var resultado = await _appController.EmpresaPresenter.DeleteEmpresa(empresaDto);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al eliminar la empresa: {ex.Message}");
            }
        }
    }
}