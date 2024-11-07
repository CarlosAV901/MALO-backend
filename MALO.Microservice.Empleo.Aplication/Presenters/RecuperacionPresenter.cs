
namespace MALO.Microservice.Empleos.Aplication.Presenters
{
    public class RecuperacionPresenter : IRecuperacionPresenter
    {
        private readonly IUnitRepository _unitRepository;
        private readonly IMapper _mapper;

        public RecuperacionPresenter(IUnitRepository unitRepository, IMapper mapper)
        {
            _unitRepository = unitRepository;
            _mapper = mapper;
        }

        public async Task<Guid> GenerarTokenRecuperacion(string email)
        {
            return await _unitRepository.recuperacionInfraestructure.GenerarTokenRecuperacion(email);
        }

        public async Task<bool> VerificarToken(Guid token)
        {
            return await _unitRepository.recuperacionInfraestructure.VerificarToken(token);
        }

        public async Task<(string mensaje, int numError)> ActualizarContrasena(Guid token, string nuevaContrasena)
        {
            return await _unitRepository.recuperacionInfraestructure.ActualizarContrasena(token, nuevaContrasena);
        }
    }
}
