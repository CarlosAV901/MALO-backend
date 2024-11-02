
using MALO.Microservice.Empleos.Domain.DTOs.Recuperacion;

namespace MALO.Microservice.Empleos.Domain.Interfaces.Infraestructure
{
    public interface IRecuperacionInfraestructure
    {
        public Task<Guid> GenerarTokenRecuperacion(string email);
        public Task<bool> VerificarToken(Guid token);
        public Task<string> ActualizarContrasena(Guid token, string nuevaContrasena);
    }
}
