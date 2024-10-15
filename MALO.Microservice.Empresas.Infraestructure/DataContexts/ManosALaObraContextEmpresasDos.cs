namespace MALO.Microservice.Empresas.Infraestructure.DataContexts
{
    public class ManosALaObraContextEmpresasDos : DbContext
    {
        public ManosALaObraContextEmpresasDos(DbContextOptions<ManosALaObraContextEmpresasDos> options) : base(options)
        {
        }

        #region Generic Dtos DB
        public DbSet<RespuestaDB> respuestaDB { get; set; }
        public DbSet<EmpresaDto> empresasDto { get; set; }
        public DbSet<ConsultaEmpresaPorIdDto> consultaEmpresaPorIdDtos { get; set; }

        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("");
            }
        }
    }
}
