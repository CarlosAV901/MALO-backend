namespace MALO.Microservice.Documentos.Infraestructure.DataContexts
{
    public class ManosALaObraContext : DbContext
    {
        public ManosALaObraContext(DbContextOptions<ManosALaObraContext> options) : base(options)
        {
        }

        #region Generic Dtos DB
        public DbSet<RespuestaDB> respuestaDB { get; set; }
        public DbSet<DocumentosDto>documentoDto {get; set;}
        public DbSet<ActualizarDocumentoDTO> actualizarDocumentoDTO {get; set;}
        public DbSet<UsuarioIdDTO> usuarioIdDTO {get; set;}


        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurar UsuarioInsertarDto como una entidad sin clave
            modelBuilder.Entity<ActualizarDocumentoDTO>().HasNoKey();
            modelBuilder.Entity<UsuarioIdDTO>().HasNoKey();
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
