
namespace MALO.Microservice.Empleos.Domain.Interfaces.Services
{
    public interface IRecuperacionPresenter
    {
        public Task<Guid> GenerarTokenRecuperacion(string email);

        public Task<bool> VerificarToken(Guid token);

        public Task<string> ActualizarContrasena(Guid token, string nuevaContrasena);

    }
}
