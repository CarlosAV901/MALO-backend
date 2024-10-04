namespace MALO.Microservice.Empleos.Domain.DTOs
{
    public class RespuestaDB
    {
        [Key]
        public int TipoError { get; set; }
        public string Mensaje { get; set; }
    }
}
