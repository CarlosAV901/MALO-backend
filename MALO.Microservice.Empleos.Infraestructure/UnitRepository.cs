

namespace MALO.Microservice.Empleos.Infraestructure
{
    public class UnitRepository: BaseDisposable, IUnitRepository
    {
        private readonly ManosALaObraContext _context;
        private readonly IConfiguration _configuration;

        public UnitRepository(ManosALaObraContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        protected override void DisposeManagedResource()
        {
            try
            {
                _context.Dispose();


                //if (_context.Database.GetDbConnection != null)
                //{
                //    System.Diagnostics.Debug.WriteLine(_context.Database.GetDbConnection().State);
                //    System.Diagnostics.Debug.WriteLine(_context.Database.GetDbConnection().ConnectionTimeout);
                //}
            }
            finally
            {
                base.DisposeManagedResource();
            }
        }
        //
        public IUsuarioInfraestructure usuarioInfraestructure => new UsusarioInfraestructure(_context);

        public IRecuperacionInfraestructure recuperacionInfraestructure => new RecuperacionInfraestructure(_context);

        public IHabilidadInfraestructure habilidadInfraestructure => new HabilidadInfraestructure(_context);

        public async ValueTask<bool> Complete()
        {
            return await _context.SaveChangesAsync() > 0;
        }



        public bool HasChanges()
        {
            return _context.ChangeTracker.HasChanges();
        }
    }
}
