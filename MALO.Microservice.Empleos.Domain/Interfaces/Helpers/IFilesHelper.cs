

namespace MALO.Microservice.Empleos.Domain.Interfaces.Helpers
{
    public interface IFilesHelper
    {
        Task<string> SubirArchivo(Stream archivo, string nombre);
        Task EliminarArchivo(string nombre);
        Task<bool> ArchivoExiste(string nombreArchivo);

    }
}
