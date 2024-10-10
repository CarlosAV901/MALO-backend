﻿using MALO.Microservice.Empleosdb.Domain.DTOs.Aplicacion;
using MALO.Microservice.Empleosdb.Domain.Interfaces.Infraestructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MALO.Microservice.Empleosdb.Infraestructure.Repositories
{
    internal class AplicacionInfraestructure: IAplicacionInfraestructure
    {
        private readonly ManosALaObraContext _context;

        public AplicacionInfraestructure(ManosALaObraContext context)
        {
            _context = context;
        }

        public async Task<List<AplicacionDto>> GetAplicaciones()
        {
            try
            {
                var resultadoBD = new SqlParameter
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
            resultadoBD,
            NumError
        };

                string sqlQuery = "EXEC dbo.SP_ConsultarAplicaciones @Resultado OUTPUT, @NumError OUTPUT";
                var dataSP = await _context.aplicacionDto.FromSqlRaw(sqlQuery, parameters).ToListAsync();
                return dataSP;
            }
            catch (SqlException ex)
            {
                throw;
            }
        }

        public async Task<AplicacionDto> GetAplicacionById(Guid aplicacionId)
        {
            try
            {
                var resultadoBD = new SqlParameter
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

                var AplicacionId = new SqlParameter
                {
                    ParameterName = "Aplicacion_id",
                    SqlDbType = SqlDbType.UniqueIdentifier,
                    Value = aplicacionId
                };

                SqlParameter[] parameters =
                {
            AplicacionId,
            resultadoBD,
            NumError
        };

                string sqlQuery = "EXEC dbo.SP_ConsultarAplicacionId @Aplicacion_id, @Resultado = @Resultado OUTPUT, @NumError = @NumError OUTPUT";
                var dataSP = await _context.aplicacionDto.FromSqlRaw(sqlQuery, parameters).ToListAsync();
                return dataSP.FirstOrDefault();
            }
            catch (SqlException ex)
            {
                throw;
            }
        }

        public async Task<string> PostAplicacion(Guid usuarioId, Guid empleoId, DateTime fechaAplicacion)
        {
            try
            {
                var resultadoBD = new SqlParameter
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

                var UsuarioId = new SqlParameter
                {
                    ParameterName = "Usuario_id",
                    SqlDbType = SqlDbType.UniqueIdentifier,
                    Value = usuarioId
                };

                var EmpleoId = new SqlParameter
                {
                    ParameterName = "Empleo_id",
                    SqlDbType = SqlDbType.UniqueIdentifier,
                    Value = empleoId
                };

                var FechaAplicacion = new SqlParameter
                {
                    ParameterName = "Fecha_aplicacion",
                    SqlDbType = SqlDbType.Date,
                    Value = fechaAplicacion
                };

                SqlParameter[] parameters =
                {
            UsuarioId,
            EmpleoId,
            FechaAplicacion,
            resultadoBD,
            NumError
        };

                string sqlQuery = "EXEC dbo.SP_AgregarAplicacion @Usuario_id, @Empleo_id, @Fecha_aplicacion, @Resultado OUTPUT, @NumError OUTPUT";
                await _context.Database.ExecuteSqlRawAsync(sqlQuery, parameters);

                return resultadoBD.Value.ToString();
            }
            catch (SqlException ex)
            {
                throw;
            }
        }

        public async Task<string> UpdateAplicacionById(Guid aplicacionId, Guid usuarioId, Guid empleoId, DateTime fechaAplicacion)
        {
            try
            {
                var resultadoBD = new SqlParameter
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

                var AplicacionId = new SqlParameter
                {
                    ParameterName = "Aplicacion_id",
                    SqlDbType = SqlDbType.UniqueIdentifier,
                    Value = aplicacionId
                };

                var UsuarioId = new SqlParameter
                {
                    ParameterName = "Usuario_id",
                    SqlDbType = SqlDbType.UniqueIdentifier,
                    Value = usuarioId
                };

                var EmpleoId = new SqlParameter
                {
                    ParameterName = "Empleo_id",
                    SqlDbType = SqlDbType.UniqueIdentifier,
                    Value = empleoId
                };

                var FechaAplicacion = new SqlParameter
                {
                    ParameterName = "Fecha_aplicacion",
                    SqlDbType = SqlDbType.Date,
                    Value = fechaAplicacion
                };

                SqlParameter[] parameters =
                {
            AplicacionId,
            UsuarioId,
            EmpleoId,
            FechaAplicacion,
            resultadoBD,
            NumError
        };

                string sqlQuery = "EXEC dbo.SP_ActualizarAplicacion @Aplicacion_id, @Usuario_id, @Empleo_id, @Fecha_aplicacion, @Resultado OUTPUT, @NumError OUTPUT";
                await _context.Database.ExecuteSqlRawAsync(sqlQuery, parameters);

                return resultadoBD.Value.ToString();
            }
            catch (SqlException ex)
            {
                throw;
            }
        }

        public async Task<string> DeleteAplicacionById(Guid aplicacionId)
        {
            try
            {
                var resultadoBD = new SqlParameter
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

                var AplicacionId = new SqlParameter
                {
                    ParameterName = "Aplicacion_id",
                    SqlDbType = SqlDbType.UniqueIdentifier,
                    Value = aplicacionId
                };

                SqlParameter[] parameters =
                {
            AplicacionId,
            resultadoBD,
            NumError
        };

                string sqlQuery = "EXEC dbo.SP_EliminarAplicacionId @Aplicacion_id, @Resultado OUTPUT, @NumError OUTPUT";
                await _context.Database.ExecuteSqlRawAsync(sqlQuery, parameters);

                return resultadoBD.Value.ToString();
            }
            catch (SqlException ex)
            {
                throw;
            }
        }

    }
}
