

using Microsoft.Identity.Client;

namespace MALO.Microservice.Empleosdb.Infraestructure.DataContexts
{
    public class ManosALaObraContext : DbContext
    {
        public ManosALaObraContext(DbContextOptions<ManosALaObraContext> options) : base(options)
        {
        }

        #region Generic Dtos DB
        public DbSet<RespuestaDB> respuestaDB { get; set; }
        public DbSet<EmpleosDto> empleoDto {get; set;}
        public DbSet<MultimediaDto> multimediaDto {get; set;}
        public DbSet<AplicacionDto> aplicacionDto {get; set;}

        public DbSet<EmpleoIdDto> empleoIdDto {get; set;}

        public DbSet<ObtenerUsuariosPorEmpleosDTO> obtenerUsuariosPorEmpleosDTO {get; set;}
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurar UsuarioInsertarDto como una entidad sin clave
            modelBuilder.Entity<ObtenerUsuariosPorEmpleosDTO>().HasNoKey();
            modelBuilder.Entity<EmpleoIdDto>().HasNoKey();
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("");
            }
        }
    }
}
