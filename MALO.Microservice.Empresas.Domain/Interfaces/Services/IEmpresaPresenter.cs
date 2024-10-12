using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MALO.Microservice.Empresas.Domain.Interfaces.Services
{
    public interface IEmpresaPresenter
    {
        Task<List<EmpresaDto>> GetEmpresa();
        Task<EmpresaDto> GetEmpresaPorId(Guid empresaId);
        Task<string> AddEmpresa(EmpresaDto empresaDto);
        Task<string> UpdateEmpresa(ActualizarEmpresaDto empresaDto);
        Task<string> DeleteEmpresa(EliminarEmpresaDto empresaDto);
    }
}
