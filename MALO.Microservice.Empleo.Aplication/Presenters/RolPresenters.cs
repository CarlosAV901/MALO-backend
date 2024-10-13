using AutoMapper;
using MALO.Microservice.Empleos.Aplication.Interfaces.Persistance;
using MALO.Microservice.Empleos.Domain.DTOs.Rol;

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
        /// Consulta un registro de la tabla CE_Users
        /// </summary>
        /// <returns></returns>
        public async Task<List<ObtenerRolesDTO>> ObtenerRoles()
        {
            return await _unitRepository.roleInfraestructure.ObtenerRoles();
        }
    }
}
