
namespace MALO.Microservice.Empresas.Infraestructure.Repositories
{
    public class EmpresaInfraestructure : IEmpresaInfraestructure
    {
        private readonly ManosALaObraContextEmpresasDos _context;

        public EmpresaInfraestructure(ManosALaObraContextEmpresasDos context)
        {
            _context = context;
        }

        /// <summary>
        /// Consulta registros de la tabla Empresas mediante un stored procedure
        /// </summary>
        /// <returns>Una lista de empresas</returns>
        public async Task<List<EmpresaDto>> GetEmpresa()
        {
            try
            {
                // Definir los parámetros de salida
                var resultadoBD = new SqlParameter
                {
                    ParameterName = "Resultado",
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 100,
                    Direction = ParameterDirection.Output
                };
                var NumError = new SqlParameter
                {
                    ParameterName = "NumError",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };

                // Ejecutar el stored procedure
                SqlParameter[] parameters =
                {
                    resultadoBD,
                    NumError
                };
                string sqlQuery = "EXEC dbo.SP_ConsultarEmpresas @Resultado OUTPUT, @NumError OUTPUT";
                var empresas = await _context.empresasDto.FromSqlRaw(sqlQuery, parameters).ToListAsync();

                // Retornar la lista completa
                return empresas; // Ahora retornamos la lista completa
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al consultar las empresas", ex);
            }
        }

        /// <summary>
        /// Consulta una empresa por ID utilizando un stored procedure
        /// </summary>
        /// <param name="empresaId">ID de la empresa</param>
        /// <returns>DTO de la empresa consultada</returns>
        public async Task<EmpresaDto> GetEmpresaPorId(Guid empresaId)
        {
            try
            {
                // Definir los parámetros de salida
                var resultadoBD = new SqlParameter
                {
                    ParameterName = "Resultado",
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 100,
                    Direction = ParameterDirection.Output
                };
                var numError = new SqlParameter
                {
                    ParameterName = "NumError",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };
                var empresaIdParam = new SqlParameter
                {
                    ParameterName = "EmpresaId",
                    SqlDbType = SqlDbType.UniqueIdentifier, // Cambia el tipo a UniqueIdentifier para Guid
                    Value = empresaId // Aquí se pasa el ID de la empresa
                };

                SqlParameter[] parameters =
                {
            empresaIdParam,
            resultadoBD,
            numError
        };

                // Ejecutar el stored procedure
                string sqlQuery = "EXEC dbo.SP_ConsultarEmpresaPorId @EmpresaId, @Resultado OUTPUT, @NumError OUTPUT";
                var empresas = await _context.empresasDto.FromSqlRaw(sqlQuery, parameters).ToListAsync();

                // Verificar si no se devolvieron resultados
                if (!empresas.Any())
                {
                    return null; // Empresa no encontrada
                }

                // Verifica el número de error
                if (numError.Value != null && (int)numError.Value == 1)
                {
                    // Retornar la primera empresa si existe
                    return empresas.FirstOrDefault();
                }
                else
                {
                    // Manejo de errores basados en el resultado
                    throw new Exception(resultadoBD.Value.ToString());
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al consultar la empresa por ID", ex);
            }
        }


        public async Task<string> AddEmpresa(InsertarEmpresaDto insertarEmpresaDto)
        {
            try
            {
                // Definir los parámetros de salida
                var resultadoBD = new SqlParameter
                {
                    ParameterName = "Resultado",
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 100,
                    Direction = ParameterDirection.Output
                };

                var numError = new SqlParameter
                {
                    ParameterName = "NumError",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };

                // Parámetros de entrada
                var nombreParam = new SqlParameter
                {
                    ParameterName = "Nombre",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = insertarEmpresaDto.nombre
                };

                var industriaParam = new SqlParameter
                {
                    ParameterName = "Industria",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = (object)insertarEmpresaDto.industria ?? DBNull.Value
                };

                var ubicacionParam = new SqlParameter
                {
                    ParameterName = "Ubicacion",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = (object)insertarEmpresaDto.ubicacion ?? DBNull.Value
                };
                var contrasenaParam = new SqlParameter
                {
                    ParameterName = "Contrasena",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = insertarEmpresaDto.contrasena
                };
                var emailParam = new SqlParameter
                {
                    ParameterName = "Email",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = insertarEmpresaDto.email
                };

                // Ejecutar el procedimiento almacenado
                SqlParameter[] parameters =
                {
                    nombreParam,
                    industriaParam,
                    ubicacionParam,
                    contrasenaParam,
                    emailParam,
                    resultadoBD,
                    numError
                };

                string sqlQuery = "EXEC dbo.SP_AgregarEmpresa @Nombre, @Industria, @Contrasena, @Email, @Ubicacion, @Resultado OUTPUT, @NumError OUTPUT";
                await _context.Database.ExecuteSqlRawAsync(sqlQuery, parameters);

                // Verifica el número de error
                if (numError.Value != null && (int)numError.Value == 1)
                {
                    return resultadoBD.Value.ToString(); // Retornar el resultado exitoso
                }
                else
                {
                    // Manejo de errores basados en el resultado
                    throw new Exception(resultadoBD.Value.ToString());
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al agregar la empresa", ex);
            }
        }

        /// <summary>
        /// Actualiza una empresa utilizando un stored procedure
        /// </summary>
        /// <param name="empresaDto">DTO de la empresa a actualizar</param>
        /// <returns>Resultado de la operación</returns>
        public async Task<string> UpdateEmpresa(ActualizarEmpresaDto empresaDto)
        {
            try
            {
                // Definir los parámetros de salida
                var resultadoBD = new SqlParameter
                {
                    ParameterName = "Resultado",
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 100,
                    Direction = ParameterDirection.Output
                };

                var numError = new SqlParameter
                {
                    ParameterName = "NumError",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };

                // Parámetros de entrada
                var idParam = new SqlParameter
                {
                    ParameterName = "Id",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = empresaDto.Id
                };

                var nombreParam = new SqlParameter
                {
                    ParameterName = "Nombre",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = empresaDto.Nombre
                };

                var industriaParam = new SqlParameter
                {
                    ParameterName = "Industria",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = (object)empresaDto.Industria ?? DBNull.Value
                };

                var ubicacionParam = new SqlParameter
                {
                    ParameterName = "Ubicacion",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = (object)empresaDto.Ubicacion ?? DBNull.Value
                };

                var emailParam = new SqlParameter
                {
                    ParameterName = "email",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = empresaDto.Email
                };

                // Ejecutar el procedimiento almacenado
                SqlParameter[] parameters =
                {
                    idParam,
                    nombreParam,
                    industriaParam,
                    ubicacionParam,
                    emailParam,
                    resultadoBD,
                    numError
                };

                string sqlQuery = "EXEC dbo.SP_ActualizarEmpresaPorId @Id, @Nombre, @Industria, @Email, @Ubicacion, @Resultado OUTPUT, @NumError OUTPUT";
                await _context.Database.ExecuteSqlRawAsync(sqlQuery, parameters);

                // Verifica el número de error
                if (numError.Value != null && (int)numError.Value == 1)
                {
                    return resultadoBD.Value.ToString(); // Retornar el resultado exitoso
                }
                else
                {
                    // Manejo de errores basados en el resultado
                    throw new Exception(resultadoBD.Value.ToString());
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al actualizar la empresa", ex);
            }
        }

        /// <summary>
        /// Elimina una empresa utilizando un stored procedure
        /// </summary>
        /// <param name="empresaDto">DTO con el ID de la empresa a eliminar</param>
        /// <returns>Resultado de la operación</returns>
        public async Task<string> DeleteEmpresa(EliminarEmpresaDto empresaDto)
        {
            try
            {
                // Definir los parámetros de salida
                var resultadoBD = new SqlParameter
                {
                    ParameterName = "Resultado",
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 100,
                    Direction = ParameterDirection.Output
                };

                var numError = new SqlParameter
                {
                    ParameterName = "NumError",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };

                // Parámetro de entrada
                var idParam = new SqlParameter
                {
                    ParameterName = "EmpresaId",
                    SqlDbType = SqlDbType.UniqueIdentifier, // Utiliza UniqueIdentifier para GUID
                    Value = Guid.Parse(empresaDto.Id)
                };

                // Ejecutar el procedimiento almacenado
                SqlParameter[] parameters =
                {
            idParam,
            resultadoBD,
            numError
        };

                string sqlQuery = "EXEC dbo.SP_EliminarEmpresaPorId @EmpresaId, @Resultado OUTPUT, @NumError OUTPUT";
                await _context.Database.ExecuteSqlRawAsync(sqlQuery, parameters);

                // Verificar el número de error
                if (numError.Value != null && (int)numError.Value == 1)
                {
                    return resultadoBD.Value.ToString(); // Retornar el mensaje exitoso
                }
                else
                {
                    // Manejo de errores basados en el resultado
                    throw new Exception(resultadoBD.Value.ToString());
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al eliminar la empresa", ex);
            }
        }
    }
}