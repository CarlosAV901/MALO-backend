
namespace MALO.Microservice.Empresas.Domain.Interfaces.Infraestructure
{
    public interface IEmpresaInfraestructure
    {
        Task<List<EmpresaDto>> GetEmpresa();
        Task<EmpresaDto> GetEmpresaPorId(Guid empresaId);
        Task<string> AddEmpresa(InsertarEmpresaDto insertarEmpresaDto);
        Task<string> UpdateEmpresa(ActualizarEmpresaDto empresaDto);
        Task<string> DeleteEmpresa(EliminarEmpresaDto empresaDto);
        Task<EmpresaDto> ValidarEmpresa(string email, string contrasena);
        Task<string> ConfirmarEmpresa(Guid token);
    }
}