
namespace MALO.Microservice.Empleosdb.Aplication.Controllers
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

        public IEmpleoPresenter EmpleoPresenter => new EmpleoPresenter(_unitRepository, _mapper);
        public IMultimediaPresenter MultimediaPresenter => new MultimediaPresenter(_unitRepository, _mapper);
        public IAplicacionPresenter AplicacionPresenter => new AplicacionPresenter(_unitRepository, _mapper);
    }
}
