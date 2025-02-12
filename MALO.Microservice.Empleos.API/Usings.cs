﻿global using MALO.Microservice.Empleos.Aplication.Interfaces.Controllers;
global using Microsoft.AspNetCore.Mvc;
global using MALO.Microservice.Empleos.Domain.DTOs.Usuario;
global using Microsoft.IdentityModel.Tokens;
global using System.IdentityModel.Tokens.Jwt;
global using System.Security.Claims;
global using System.Text;

global using Microsoft.AspNetCore.Authorization;
global using Microsoft.IdentityModel.JsonWebTokens;
global using MALO.Microservice.Empleo.Aplication;
global using MALO.Microservice.Empleos.API.Swagger.Filters;
global using MALO.Microservice.Empleos.Infraestructure;
global using Microsoft.OpenApi.Models;
global using MALO.Microservice.Empleos.API.Extensions;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
