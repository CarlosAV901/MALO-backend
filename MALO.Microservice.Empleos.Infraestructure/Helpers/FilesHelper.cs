
using Firebase.Storage;
using MALO.Microservice.Empleos.Domain.Interfaces.Helpers;

namespace MALO.Microservice.Empleos.Infraestructure.Helpers
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
            var nombreImagen = Path.GetFileName(nombre);
            var nombreArchivo = $"_{Guid.NewGuid()}_{nombreImagen}";

            var task = new FirebaseStorage(
                _ruta,
                new FirebaseStorageOptions
                {
                    ThrowOnCancel = true
                })
                .Child("Fotos_perfil")
                .Child(nombreArchivo)
                .PutAsync(archivo, cancellation.Token);

            var downloadURL = await task;
            return downloadURL;
        }

        public async Task EliminarArchivo(string nombre)
        {
            try
            {
                string nombreArchivo = ObtenerNombreDesdeUrl(nombre);

                Console.WriteLine($"Eliminando archivo: {nombreArchivo}");

                var cancellation = new CancellationTokenSource();

                // Imprime la ruta para verificar que sea la correcta
                Console.WriteLine($"Eliminando archivo en ruta: {nombre}");

                await new FirebaseStorage(_ruta)
                    .Child("Fotos_perfil")
                    .Child(nombreArchivo)
                    .DeleteAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar el archivo: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> ArchivoExiste(string nombre)
        {
            try
            {
                var cancellation = new CancellationTokenSource();
                string nombreArchivo = ObtenerNombreDesdeUrl(nombre);

                Console.WriteLine($"Eliminando archivo: {nombreArchivo}");

                // Intentar acceder al archivo en Firebase
                var task = new FirebaseStorage(_ruta)
                    .Child("Fotos_perfil")
                    .Child(nombreArchivo)
                    .GetDownloadUrlAsync();

                // Intentar obtener la URL para verificar su existencia
                var downloadUrl = await task;

                Console.WriteLine($"El archivo existe: {downloadUrl}");
                return true;
            }
            catch (Exception ex)
            {
                // Si se produce un error, asumimos que el archivo no existe
                Console.WriteLine($"El archivo no existe o hubo un error al verificar: {ex.Message}");
                return false;
            }
        }

        // Método para extraer el nombre del archivo desde la URL
        private string ObtenerNombreDesdeUrl(string url)
        {
            // Decodificar la URL primero para manejar caracteres especiales
            string decodedUrl = Uri.UnescapeDataString(url);

            // Buscar el índice del último '/' en la URL y extraer el nombre
            int index = decodedUrl.LastIndexOf('/');
            if (index >= 0)
            {
                string nombreConToken = decodedUrl.Substring(index + 1);
                // Eliminar cualquier parámetro como "?alt=media&token=..."
                int queryIndex = nombreConToken.IndexOf('?');
                if (queryIndex >= 0)
                {
                    nombreConToken = nombreConToken.Substring(0, queryIndex);
                }
                return nombreConToken;
            }
            return string.Empty;
        }
    }
}
