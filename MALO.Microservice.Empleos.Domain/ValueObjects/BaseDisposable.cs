namespace MALO.Microservice.Empleos.Domain.ValueObjects
{
    public class BaseDisposable: IDisposable
    {
        #region IDisposable Support
        public bool DisposedValue { get; private set; }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
            System.Diagnostics.Debug.WriteLine("BaseDisposable");
        }
        private void Dispose(bool disposing)
        {
            if (!DisposedValue)
            {
                if (disposing)
                {
                    DisposeManagedResource();
                }

                DisposeUnmanagedResource();
                DisposedValue = true;
            }
        }
        ~BaseDisposable()
        {
            Dispose(false);
        }
        protected virtual void DisposeManagedResource() { }
        protected virtual void DisposeUnmanagedResource() { }

        #endregion
    }
}
