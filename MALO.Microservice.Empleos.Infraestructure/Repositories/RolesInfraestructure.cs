using MALO.Microservice.Empleos.Domain.DTOs.Rol;
using MALO.Microservice.Empleos.Domain.Interfaces.Infraestructure;

namespace MALO.Microservice.Empleos.Infraestructure.Repositories
{
    public class RolesInfraestructure : IRoleInfraestructure
    {
        private readonly ManosALaObraContext _context;

        public RolesInfraestructure(ManosALaObraContext context)
        {
            _context = context;
        }

        public async Task<List<ObtenerRolesDTO>> ObtenerRoles()
        {
            try
            {
                var resultadoDb = new SqlParameter
                {
                    ParameterName = "Resultado",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100,
                    Direction = ParameterDirection.Output
                };
                var NumError = new SqlParameter
                {
                    ParameterName = "NumError",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };
                SqlParameter[] parameters =
                {
                    resultadoDb,
                    NumError
                };
                string sqlQuery = "EXEC [dbo].[ObtenerRoles] @Resultado OUTPUT, @NumError OUTPUT";
                var dataSP = await _context.obtenerRolesDTO.FromSqlRaw(sqlQuery, parameters).ToListAsync();

                return dataSP;

            }
            catch (SqlException ex)
            {
                throw;
            }
        }
    }
}
