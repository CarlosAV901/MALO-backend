


namespace MALO.Microservice.Empresas.Aplication.Presenters
{
    public class EmpresaPresenter : IEmpresaPresenter
    {
        private readonly IUnitRepositoryEmpresas _unitRepository;
        private readonly IMapper _mapper;

        public EmpresaPresenter(IUnitRepositoryEmpresas unitRepository, IMapper mapper)
        {
            _unitRepository = unitRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Consulta un registro de la tabla Empresas
        /// </summary>
        /// <returns></returns>
        public async Task<List<EmpresaDto>> GetEmpresa()
        {
            return await _unitRepository.EmpresaInfraestructure.GetEmpresa();
        }

        /// <summary>
        /// Consulta una empresa por su ID
        /// </summary>
        /// <param name="empresaId">ID de la empresa</param>
        /// <returns>El DTO de la empresa consultada</returns>
        public async Task<EmpresaDto> GetEmpresaPorId(Guid empresaId)
        {
            // Llama al repositorio y pasa el ID
            return await _unitRepository.EmpresaInfraestructure.GetEmpresaPorId(empresaId);
        }

        public async Task<string> AddEmpresa(EmpresaDto empresaDto)
        {
            return await _unitRepository.EmpresaInfraestructure.AddEmpresa(empresaDto);
        }

        /// <summary>
        /// Actualiza un registro de la tabla Empresas
        /// </summary>
        /// <param name="empresaDto">DTO con los datos actualizados de la empresa</param>
        /// <returns>Resultado de la actualización</returns>
        public async Task<string> UpdateEmpresa(ActualizarEmpresaDto empresa)
        {
            // Mapeo y llamada a la infraestructura para actualizar
            return await _unitRepository.EmpresaInfraestructure.UpdateEmpresa(empresa);
        }

        /// <summary>
        /// Elimina un registro de la tabla Empresas
        /// </summary>
        /// <param name="empresaDto">DTO con los datos de la empresa a eliminar</param>
        /// <returns>Resultado de la eliminación</returns>
        public async Task<string> DeleteEmpresa(EliminarEmpresaDto empresaDto)
        {
            // Llama a la infraestructura para eliminar
            return await _unitRepository.EmpresaInfraestructure.DeleteEmpresa(empresaDto);
        }
    }
}
