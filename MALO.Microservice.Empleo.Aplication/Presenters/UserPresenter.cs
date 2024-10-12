using AutoMapper;
using MALO.Microservice.Empleos.Aplication.Interfaces.Persistance;
using MALO.Microservice.Empleos.Domain.DTOs.Usuario;

namespace MALO.Microservice.Empleos.Aplication.Presenters
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

        public async Task<UsuarioConDetallesDTO> ObtenerUsuarioPorId(Guid id)
        {
            return await _unitRepository.usuarioInfraestructure.ObtenerUsuarioPorId(id);
        }

        public async Task<List<UsuarioConDetallesDTO>> ObtenerUsuarios()
        {
            return await _unitRepository.usuarioInfraestructure.ObtenerUsuarios();
        }

        public async Task<UsuarioConDetallesDTO> InsertarUsuario(UsuarioInsertarDto usuarioInsertarDto)
        {
            return await _unitRepository.usuarioInfraestructure.InsertarUsuario(usuarioInsertarDto);
        }

        public async Task<string> EliminarUsuario(Guid id)
        {
            return await _unitRepository.usuarioInfraestructure.EliminarUsuario(id);
        }

        public async Task<UsuarioConDetallesDTO> ActualizarUsuario(Guid id, ActualizarUsuarioDTO actualizarUsuarioDTO)
        {
            return await _unitRepository.usuarioInfraestructure.ActualizarUsuario(id, actualizarUsuarioDTO);
        }
    }
}
