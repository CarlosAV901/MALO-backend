using MALO.Microservice.Empresas.Domain.DTOs.Recuperacion;

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
        public DbSet<RecuperacionDTO> recuperacionDto {  get; set; }
        public DbSet<CambioContrasenaDTO> cambioContrasenaDTO { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<InsertarEmpresaDto>().HasNoKey();
            modelBuilder.Entity<CambioContrasenaDTO>().HasNoKey();
            modelBuilder.Entity<RecuperacionDTO>().HasNoKey();
        }

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
