
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


        public DbSet<EmpleoIdDto> empleoIdDto {get; set;}
        public DbSet<UsuarioIdDTO> usuarioIdDTO {get; set;}
        public DbSet<ObtenerUsuariosPorEmpleosDTO> obtenerUsuariosPorEmpleosDTO {get; set;}
        public DbSet<AplicarEmpleoDTO> aplicarEmpleoDTO {get; set;}
        public DbSet<ObtenerEmpleosPorUsuarioDTO> obtenerEmpleosPorUsuarioDTO {get; set;}
        public DbSet<AplicacionesPorFechaDTO> aplicacionesPorFechaDTO {get; set;}

        public DbSet<ActualizarMultimediaDTO> actualizarMultimediaDTO {get; set;}

        public DbSet<RegistrarVisualizacionDTO> registrarVisualizacionDTO {get; set;}
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurar UsuarioInsertarDto como una entidad sin clave
            modelBuilder.Entity<ObtenerUsuariosPorEmpleosDTO>().HasNoKey();
            modelBuilder.Entity<EmpleoIdDto>().HasNoKey();
            modelBuilder.Entity<ObtenerEmpleosPorUsuarioDTO>().HasNoKey();
            modelBuilder.Entity<UsuarioIdDTO>().HasNoKey();
            modelBuilder.Entity<AplicarEmpleoDTO>().HasNoKey();
            modelBuilder.Entity<AplicacionesPorFechaDTO>().HasNoKey();
            modelBuilder.Entity<RegistrarVisualizacionDTO>().HasNoKey();
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
