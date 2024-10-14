
namespace MALO.Microservice.Empleos.Infraestructure.DataContexts
{
    public class ManosALaObraContext : DbContext
    {
        public ManosALaObraContext(DbContextOptions<ManosALaObraContext> options) : base(options)
        {
        }

        #region Generic Dtos DB
        public DbSet<RespuestaDB> respuestaDB { get; set; }
        public DbSet<UsuarioDto>usuarioDto {get; set;}
        public DbSet<UsuarioConDetallesDTO>usuarioDtoDetalles {get; set;}
        public DbSet<ActualizarUsuarioDTO> actualizarUsuarioDto { get; set;}

        public DbSet<InsertarRolDTO> insertarRolDTOs {get; set;}

        public DbSet<ObtenerRolesDTO> obtenerRolesDTO {get; set;}
        public DbSet<ActualizarRolDTO> actualizarRolDTO {get; set;}
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurar UsuarioInsertarDto como una entidad sin clave
            modelBuilder.Entity<UsuarioInsertarDto>().HasNoKey();

            modelBuilder.Entity<InsertarRolDTO>().HasNoKey();
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
