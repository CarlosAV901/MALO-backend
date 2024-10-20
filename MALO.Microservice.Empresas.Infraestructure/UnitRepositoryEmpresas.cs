

namespace MALO.Microservice.Empresas.Infraestructure
{
    public class UnitRepositoryEmpresas : BaseDisposable, IUnitRepositoryEmpresas
    {
        private readonly ManosALaObraContextEmpresasDos _context;
        private readonly IConfiguration _configuration;

        public UnitRepositoryEmpresas(ManosALaObraContextEmpresasDos context, IConfiguration configuration)
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

        // Adaptación para empresas en lugar de usuarios
        public IEmpresaInfraestructure EmpresaInfraestructure => new EmpresaInfraestructure(_context);

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
