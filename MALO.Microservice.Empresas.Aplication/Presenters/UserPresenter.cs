using AutoMapper;
using MALO.Microservice.Empresas.Aplication.Interfaces.Persistance;
using MALO.Microservice.Empresas.Domain.DTOs.Usuario;
using MALO.Microservice.Empresas.Domain.Interfaces.Services;

namespace MALO.Microservice.Empresas.Aplication.Presenters
{
    public class UserPresenter : IUserPresenter
    {
        private readonly IUnitRepository _unitRepository;
        private readonly IMapper _mapper;

        public UserPresenter(IUnitRepository unitRepository, IMapper mapper)
        {
            _unitRepository = unitRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Consulta un registro de la tabla CE_Users
        /// </summary>
        /// <returns></returns>
        public async Task<UsuarioDto> GetUser()
        {
            return await _unitRepository.usuarioInfraestructure.GetUser();
        }
    }
}
