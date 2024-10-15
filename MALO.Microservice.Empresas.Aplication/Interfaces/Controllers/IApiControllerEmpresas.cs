using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MALO.Microservice.Empresas.Aplication.Interfaces.Controllers
{
    public interface IApiControllerEmpresas
    {
        IEmpresaPresenter EmpresaPresenter { get; }
    }
}
