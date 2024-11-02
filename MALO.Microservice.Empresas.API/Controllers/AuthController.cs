
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MALO.Microservice.Empresas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ApiController
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="appController"></param>
        public AuthController(IApiControllerEmpresas appController) : base(appController)
        {

        }

        // Login y generación del JWT
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto request)
        {
            var empresa = await _appController.EmpresaPresenter.ValidarEmpresa(request.email, request.contrasena);
          
            if (empresa == null)
            {
                return Unauthorized(new { message = "Correo o contraseña incorrectos" });
            }

            if (!empresa.correo_confirmado)
            {
                return Unauthorized("Debe confirmar su correo antes de iniciar sesion.");
            }

            // Generar JWT
            var token = GenerarTokenJWT(empresa);

            return Ok(new
            {
                message = "Login correcto",
                result = true,
                token
            });
        }

        // Método para generar el token JWT
        private string GenerarTokenJWT(EmpresaDto empresaDto)
        {
            var claims = new[]
            {
            new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Sub, empresaDto.Id.ToString()),
            new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Email, empresaDto.Email),
            new Claim("rol", empresaDto.Rol.ToString())
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appController.GetJwtConfigValue("Key")));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _appController.GetJwtConfigValue("Issuer"),
                audience: _appController.GetJwtConfigValue("Audience"),
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
