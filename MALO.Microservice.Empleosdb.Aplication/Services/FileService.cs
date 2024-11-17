using MALO.Microservice.Empleosdb.Domain.Interfaces.Helpers;
using Microsoft.AspNetCore.Http;


namespace MALO.Microservice.Empleosdb.Aplication.Services
{
    public class FileService
    {
        private readonly IFilesHelper _filesHelper;

        public FileService(IFilesHelper filesHelper)
        {
            _filesHelper = filesHelper;
        }

        public async Task<string> SubirArchivo(IFormFile archivo)
        {
            if (archivo == null || archivo.Length == 0)
            {
                throw new ArgumentException("El archivo no es válido.");
            }

            var nombre = archivo.FileName;
            using var stream = archivo.OpenReadStream();
            var urlImagen = await _filesHelper.SubirArchivo(stream, nombre);
            return urlImagen;
        }

        public async Task EliminarArchivo(string nombreArchivo)
        {
            await _filesHelper.EliminarArchivo(nombreArchivo);
        }

        public async Task<bool> ArchivoExiste(string nombreArchivo)
        {
            return await _filesHelper.ArchivoExiste(nombreArchivo);
        }

    }
}
