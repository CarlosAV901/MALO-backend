
namespace MALO.Microservice.Empresas.Aplication.Presenters
{
    public class RecuperacionPresenter : IRecuperacionPresenter
    {
        private readonly IUnitRepositoryEmpresas _unitRepository;
        private readonly IMapper _mapper;

        public RecuperacionPresenter(IUnitRepositoryEmpresas unitRepository, IMapper mapper)
        {
            _unitRepository = unitRepository;
            _mapper = mapper;
        }

        public async Task<Guid> GenerarTokenRecuperacion(string email)
        {
            return await _unitRepository.RecuperacionInfraestructure.GenerarTokenRecuperacion(email);
        }

        public async Task<bool> VerificarToken(Guid token)
        {
            return await _unitRepository.RecuperacionInfraestructure.VerificarToken(token);
        }

        public async Task<(string mensaje, int numError)> ActualizarContrasena(Guid token, string nuevaContrasena)
        {
            return await _unitRepository.RecuperacionInfraestructure.ActualizarContrasena(token, nuevaContrasena);
        }
    }
}
