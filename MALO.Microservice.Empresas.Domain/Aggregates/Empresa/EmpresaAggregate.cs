namespace MALO.Microservice.Empresas.Domain.Aggregates.Empresa
{
    public class EmpresaAggregate
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Industria { get; set; }
        public string Ubicacion { get; set; }
    }
}
