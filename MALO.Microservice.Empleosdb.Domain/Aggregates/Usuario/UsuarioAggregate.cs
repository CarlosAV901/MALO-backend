
namespace MALO.Microservice.Empleosdb.Domain.Aggregates.Usuario
{
    public class UsuarioAggregate
    {
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Contrasena { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int RolId { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public int EstadoId { get; set; }
        public int MunicipioId { get; set; }
        public int LocalidadId { get; set; }
    }
}
