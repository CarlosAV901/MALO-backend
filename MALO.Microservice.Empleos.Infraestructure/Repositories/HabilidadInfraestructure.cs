
using MALO.Microservice.Empleos.Domain.DTOs.Habilidad;

namespace MALO.Microservice.Empleos.Infraestructure.Repositories
{
    public class HabilidadInfraestructure : IHabilidadInfraestructure
    {
        private readonly ManosALaObraContext _context;

        public HabilidadInfraestructure(ManosALaObraContext context)
        {
            _context = context;
        }

        public async Task<List<ObtenerHabilidadesDTO>> ObtenerHabilidades()
        {
            try
            {
                var resutado = new SqlParameter { ParameterName = "Resultado", SqlDbType = SqlDbType.NVarChar, Size = 100, Direction = ParameterDirection.Output };
                var NumError = new SqlParameter { ParameterName = "NumError", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };

                SqlParameter[] parameters =
                {
                    resutado,
                    NumError
                };

                string sqlQuery = "Exec SP_ObtenerHabilidades @Resultado OUTPUT, @NumError OUTPUT";
                var dataSp = await _context.obtenerHabilidadesDTO.FromSqlRaw(sqlQuery,parameters).ToListAsync();

                return dataSp;

            }
            catch (SqlException ex)
            {
                throw new Exception("error al intentar la operacion", ex);
            }
        }

        public async Task<ObtenerHabilidadesDTO> ObtenerHabilidadPorId(int id)
        {
            try
            {
                var idParam = new SqlParameter { ParameterName = "habilidadId", SqlDbType = SqlDbType.Int, Value = id };
                var resultado = new SqlParameter { ParameterName = "Resultado", SqlDbType = SqlDbType.NVarChar, Size = 100, Direction = ParameterDirection.Output };
                var NumError = new SqlParameter { ParameterName = "NumError", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };

                SqlParameter[] parameters =
                {
                    idParam,
                    resultado,
                    NumError
                };

                string sqlQuery = "EXEC SP_ObtenerHabilidadPorID @habilidadId, @Resultado OUTPUT, @NumError OUTPUT";
                var dataSp = await _context.obtenerHabilidadesDTO.FromSqlRaw( sqlQuery,parameters).ToListAsync();

                return dataSp.FirstOrDefault();

            }
            catch (SqlException ex)
            {
                throw;
            }
        }

        public async Task<string> InsertarHabilidad(string descripcion)
        {
            try
            {
                var descripcionParam = new SqlParameter { ParameterName = "Descripcion", SqlDbType = SqlDbType.NVarChar, Value = descripcion };
                var resultado = new SqlParameter { ParameterName = "Resultado", SqlDbType = SqlDbType.NVarChar, Size = 100, Direction = ParameterDirection.Output };
                var NumError = new SqlParameter { ParameterName = "NumError", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };
                var habilidadId = new SqlParameter { ParameterName = "HabilidadId", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };

                SqlParameter[] parameters =
                {
                    descripcionParam,
                    resultado,
                    NumError,
                    habilidadId
                };

                string sqlQuery = "EXEC SP_InsertarHabilidad @Descripcion, @Resultado OUTPUT, @NumError OUTPUT, @HabilidadId OUTPUT";
                await _context.Database.ExecuteSqlRawAsync(sqlQuery,parameters);
               
                return "Habilidad insertada correctamente ";

            }
            catch (SqlException ex)
            {
                throw;
            }
        }

    }
}
