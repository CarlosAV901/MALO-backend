


namespace MALO.Microservice.Empleos.Aplication.Controllers
{
    public class ApiController : IApiController
    {
        private readonly IUnitRepository _unitRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;


        public ApiController(IUnitRepository unitRepository, IMapper mapper, IConfiguration configuration)
        {
            _unitRepository = unitRepository;
            _mapper = mapper;
            _configuration = configuration;
        }

        public IUserPresenter UserPresenter => new UserPresenter(_unitRepository, _mapper);

        public IRecuperacionPresenter RecuperacionPresenter => new RecuperacionPresenter(_unitRepository, _mapper);

        public IHabilidadPresenter HabilidadPresenter => new HabilidadPresenter(_unitRepository, _mapper);


        // Implementación para obtener valores de configuración de JWT
        public string GetJwtConfigValue(string key)
        {
            return _configuration[$"Jwt:{key}"];
        }
    }
}
