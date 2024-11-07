
namespace MALO.Microservice.Empresas.Domain.Interfaces.Services
{
    public interface IRecuperacionPresenter
    {
        public Task<Guid> GenerarTokenRecuperacion(string email);
        public Task<bool> VerificarToken(Guid token);
        public Task<(string mensaje, int numError)> ActualizarContrasena(Guid token, string nuevaContrasena);
    }
}
