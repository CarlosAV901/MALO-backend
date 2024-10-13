using AutoMapper;
using MALO.Microservice.Empleos.Aplication.Interfaces.Controllers;
using MALO.Microservice.Empleos.Aplication.Interfaces.Persistance;
using MALO.Microservice.Empleos.Aplication.Presenters;
using MALO.Microservice.Empleos.Domain.Interfaces.Services;
using Microsoft.Extensions.Configuration;


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

        public IRolPresenter RolPresenter => new RolPresenters(_unitRepository, _mapper);
    }
}
