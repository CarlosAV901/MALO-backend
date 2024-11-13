
using MALO.Microservice.Empleos.Domain.DTOs.Habilidad;
using MALO.Microservice.Empleos.Domain.DTOs.Recuperacion;

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
        public DbSet<UsuarioInsertarDto> usuarioInsertarDtos {get; set;}
        public DbSet<ConfirmarUsusarioDTO> confirmarUsusarioDTO {get; set;}

        public DbSet<RecuperacionDTO> recuperacionDTO { get; set;}
        public DbSet<CambioContrasenaDTO> cambioContrasenaDTO { get; set;}

        public DbSet<InsertarHabilidadDTO> insertarHabilidadDTO {get; set;}
        public DbSet<ObtenerHabilidadesDTO> obtenerHabilidadesDTO {get; set;}
        public DbSet<ActualizarHabilidadDTO> actualizarHabilidadDTO { get; set;}
        public DbSet<NuevoTokenDTO> nuevoTokenDTO {get; set;}

        public DbSet<LoginDTO> loginDto { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurar UsuarioInsertarDto como una entidad sin clave
            modelBuilder.Entity<UsuarioInsertarDto>().HasNoKey();
            modelBuilder.Entity<ConfirmarUsusarioDTO>().HasNoKey();
            modelBuilder.Entity<RecuperacionDTO>().HasNoKey();
            modelBuilder.Entity<CambioContrasenaDTO>().HasNoKey();

            modelBuilder.Entity<InsertarHabilidadDTO>().HasNoKey();

            modelBuilder.Entity<LoginDTO>().HasNoKey();

            modelBuilder.Entity<NuevoTokenDTO>().HasNoKey();
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
