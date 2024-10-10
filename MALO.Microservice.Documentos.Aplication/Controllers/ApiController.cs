using AutoMapper;
using MALO.Microservice.Documentos.Aplication.Interfaces.Controllers;
using MALO.Microservice.Documentos.Aplication.Interfaces.Persistance;
using MALO.Microservice.Documentos.Domain.Interfaces.Services;
using MALO.Microservice.Empleos.Aplication.Interfaces.Controllers;
using MALO.Microservice.Empleos.Aplication.Interfaces.Persistance;
using MALO.Microservice.Empleos.Aplication.Presenters;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MALO.Microservice.Documentos.Aplication.Controllers
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
    }
}
