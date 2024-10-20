namespace MALO.Microservice.Empleos.Aplication.Presenters
{
    public class RolPresenters : IRolPresenter
    {
        private readonly IUnitRepository _unitRepository;
        private readonly IMapper _mapper;

        public RolPresenters(IUnitRepository unitRepository, IMapper mapper)
        {
            _unitRepository = unitRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Consulta los registros de la tabla roles
        /// </summary>
        /// <returns></returns>
        public async Task<List<ObtenerRolesDTO>> ObtenerRoles()
        {
            return await _unitRepository.roleInfraestructure.ObtenerRoles();
        }

        /// <summary>
        /// Consulta registro por id de la tabla roles
        /// </summary>
        /// <returns></returns>
        public async Task<ObtenerRolesDTO> ObtenerRolPorId(int id)
        {
            return await _unitRepository.roleInfraestructure.ObtenerRolPorId(id);
        }

        /// <summary>
        /// Consulta registro por id de la tabla roles
        /// </summary>
        /// <returns></returns>
        public async Task<ActualizarRolDTO> ActualizarRol(int id, ActualizarRolDTO actualizarRolDTO)
        {
            return await _unitRepository.roleInfraestructure.ActualizarRol(id, actualizarRolDTO);
        }

        /// <summary>
        /// Inserta en la tabla de roles
        /// </summary>
        /// <returns></returns>
        public async Task<InsertarRolDTO> InsertarRol(InsertarRolDTO insertarRolDTO)
        {
            return await _unitRepository.roleInfraestructure.InsertarRol(insertarRolDTO);
        }

        /// <summary>
        /// Eliminar un rol
        /// </summary>
        /// <returns></returns>
        public async Task<string> EliminarRol(int id)
        {
            return await _unitRepository.roleInfraestructure.EliminarRol(id);
        }
    }
}
