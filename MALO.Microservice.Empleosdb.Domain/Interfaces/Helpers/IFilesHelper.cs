namespace MALO.Microservice.Empleosdb.Domain.Interfaces.Helpers
{
    public interface IFilesHelper
    {
        Task<string> SubirArchivo(Stream archivo, string nombre);
        Task EliminarArchivo(string nombre);

    }
}
