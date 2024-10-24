
namespace MALO.Microservice.Empresas.Aplication.Controllers
{
    public class ApiController : IApiControllerEmpresas
    {
        private readonly IUnitRepositoryEmpresas _unitRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;


        public ApiController(IUnitRepositoryEmpresas unitRepository, IMapper mapper, IConfiguration configuration)
        {
            _unitRepository = unitRepository;
            _mapper = mapper;
            _configuration = configuration;
        }

        public IEmpresaPresenter EmpresaPresenter => new EmpresaPresenter(_unitRepository, _mapper);

        public string GetJwtConfigValue(string key)
        {
            return _configuration[$"Jwt:{key}"];
        }
    }
}
