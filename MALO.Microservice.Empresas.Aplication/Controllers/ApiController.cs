﻿using AutoMapper;
using MALO.Microservice.Empresas.Aplication.Interfaces.Persistance;
using MALO.Microservice.Empresas.Aplication.Presenters;
using MALO.Microservice.Empresas.Aplication.Interfaces.Controllers;
using MALO.Microservice.Empresas.Domain.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MALO.Microservice.Empresas.Aplication.Controllers
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