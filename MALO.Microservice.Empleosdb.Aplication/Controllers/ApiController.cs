using AutoMapper;
using MALO.Microservice.Empleosdb.Aplication.Interfaces.Controllers;
using MALO.Microservice.Empleosdb.Aplication.Interfaces.Persistance;
using MALO.Microservice.Empleosdb.Aplication.Presenters;
using MALO.Microservice.Empleosdb.Domain.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
