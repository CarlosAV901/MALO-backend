using MALO.Microservice.Empresas.Domain.DTOs.Empresa;
using MALO.Microservice.Empresas.Domain.Interfaces.Infraestructure;


namespace MALO.Microservice.Empresas.Application
{
    public class EmpresasService
    {
        private readonly IEmpresasRepository _empresasRepository;

        public EmpresasService(IEmpresasRepository empresasRepository)
        {
            _empresasRepository = empresasRepository;
        }

        public async Task<IEnumerable<EmpresaDto>> ObtenerEmpresas()
        {
            return await _empresasRepository.ConsultarEmpresas();
        }
        public async Task AgregarEmpresa(EmpresaDto nuevaEmpresa)
        {
            await _empresasRepository.AgregarEmpresa(nuevaEmpresa);
        }

        public async Task<EmpresaDto> ConsultarEmpresaPorId(string empresaId)
        {
            return await _empresasRepository.ConsultarEmpresaPorId(empresaId);
        }
        // por id pero sin el body
        public async Task<EmpresaDto> ConsultarEmpresaPorId2(string empresaId)
        {
            return await _empresasRepository.ConsultarEmpresaPorId2(empresaId);
        }
        public async Task EliminarEmpresaPorId(string id)
        {
            await _empresasRepository.EliminarEmpresaPorId(id);
        }

        //actualizar
        public async Task ActualizarEmpresa(ActualizarEmpresaDto empresa)
        {
            await _empresasRepository.ActualizarEmpresa(empresa);
        }


    }
}
