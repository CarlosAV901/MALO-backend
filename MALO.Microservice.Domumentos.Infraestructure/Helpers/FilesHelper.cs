
using Firebase.Storage;
using MALO.Microservice.Documentos.Domain.Interfaces.Helpers;

namespace MALO.Microservice.Domumentos.Infraestructure.Helpers
{
    public class FilesHelper : IFilesHelper
    {
        private readonly string _ruta;

        public FilesHelper(IConfiguration configuration)
        {
            _ruta = configuration["Firebase:Ruta"];
        }

        public async Task<string> SubirArchivo(Stream archivo, string nombre)
        {
            var cancellation = new CancellationTokenSource();

            var task = new FirebaseStorage(
                _ruta,
                new FirebaseStorageOptions
                {
                    ThrowOnCancel = true
                })
                .Child("Documentos")
                .Child(nombre)
                .PutAsync(archivo, cancellation.Token);

            var downloadURL = await task;
            return downloadURL;
        }

    }
}
