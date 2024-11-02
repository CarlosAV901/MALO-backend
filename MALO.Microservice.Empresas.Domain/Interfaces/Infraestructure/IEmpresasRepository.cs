namespace MALO.Microservice.Empresas.Domain.Interfaces.Infraestructure
{
    public interface IEmpresasRepository
    {
        Task<IEnumerable<EmpresaDto>> ConsultarEmpresas();
        Task AgregarEmpresa(EmpresaDto nuevaEmpresa);
        Task<EmpresaDto> ConsultarEmpresaPorId(string empresaId);
        Task<EmpresaDto> ConsultarEmpresaPorId2(string empresaId);
        Task EliminarEmpresaPorId(string id);
        Task ActualizarEmpresa(ActualizarEmpresaDto empresa);
        Task<string> ConfirmarEmpresa(Guid token);

    }
}
