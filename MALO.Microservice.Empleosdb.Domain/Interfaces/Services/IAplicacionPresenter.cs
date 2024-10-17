using MALO.Microservice.Empleosdb.Domain.DTOs.Aplicacion;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MALO.Microservice.Empleosdb.Domain.Interfaces.Services
{
    public interface IAplicacionPresenter
    {
        Task<List<AplicacionDto>> GetAplicaciones();
        Task<AplicacionDto> GetAplicacionById([FromBody] AplicacionIdDto request);
        Task<AplicacionDto> GetAplicacionByEmpleo([FromBody] AplicacionEmpleoId request);
        Task<AplicacionDto> GetAplicacionByUsuario([FromBody] AplicacionUsuarioIdDto request);
        Task<string> PostAplicacion([FromBody] AplicacionPostDto request);
        Task<string> UpdateAplicacionById([FromBody] AplicacionUpdateDto request);
        Task<string> DeleteAplicacionById([FromBody] AplicacionIdDto request);
    }
}