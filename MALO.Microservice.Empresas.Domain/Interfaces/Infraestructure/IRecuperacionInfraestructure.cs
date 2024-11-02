

namespace MALO.Microservice.Empresas.Domain.Interfaces.Infraestructure
{
    public interface IRecuperacionInfraestructure
    {
        public Task<Guid> GenerarTokenRecuperacion(string email);
        public Task<bool> VerificarToken(Guid token);
        public Task<string> ActualizarContrasena(Guid token, string nuevaContrasena);
    }
}
