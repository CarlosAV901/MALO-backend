
namespace MALO.Microservice.Empleos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ApiController
    {

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="appController"></param>
        public AuthController(IApiController appController) : base(appController)
        {

        }

        // Login y generación del JWT
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO request)
        {
            var usuario = await _appController.UserPresenter.ValidarUsuario(request.email, request.contrasena);

            if(usuario == null)
            {
                return Unauthorized(new { message = "Correo o contraseña incorrectos" });
            }

            // Generar JWT
            var token = GenerarTokenJWT(usuario);

            return Ok(new
            {
                message = "Login correcto",
                result = true,
                token
            });
        }

        // Método para generar el token JWT
        private string GenerarTokenJWT(UsuarioConDetallesDTO usuarioConDetallesDTO)
        {
            var claims = new[]
            {
            new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Sub, usuarioConDetallesDTO.UsuarioId.ToString()),
            new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Email, usuarioConDetallesDTO.email),
            new Claim("rol", usuarioConDetallesDTO.rol.ToString())
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
