using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MALO.Microservice.Empresas.Domain.DTOs;
using MALO.Microservice.Empresas.Infrastructure.Interfaces;

namespace MALO.Microservice.Empresas.Infrastructure.Repositories
{
    public class EmpresaInfrastructure : IEmpresaInfrastructure
    {
        private readonly ManosALaObraContext _context;

        public EmpresaInfrastructure(ManosALaObraContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EmpresaDTO>> ConsultarEmpresas()
        {
            var resultado = new List<EmpresaDTO>();

            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "dbo.SP_ConsultarEmpresas";  // Nombre del stored procedure
                command.CommandType = CommandType.StoredProcedure;

                if (command.Connection.State != ConnectionState.Open)
                {
                    command.Connection.Open();
                }

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        resultado.Add(new EmpresaDTO
                        {
                            Id = reader.GetGuid(0),
                            Nombre = reader.GetString(1),
                            Industria = reader.GetString(2),
                            Ubicacion = reader.GetString(3)
                        });
                    }
                }
            }

            return resultado;
        }
    }
}
