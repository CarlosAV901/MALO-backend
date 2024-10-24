
namespace MALO.Microservice.Empresas.Domain.Interfaces.Services
{
    public interface IEmpresaPresenter
    {
        Task<List<EmpresaDto>> GetEmpresa();
        Task<EmpresaDto> GetEmpresaPorId(Guid empresaId);
        Task<string> AddEmpresa(InsertarEmpresaDto insertarEmpresaDto);
        Task<string> UpdateEmpresa(ActualizarEmpresaDto empresaDto);
        Task<string> DeleteEmpresa(EliminarEmpresaDto empresaDto);
        Task<EmpresaDto> ValidarEmpresa(string email, string contrasena);
    }
}
