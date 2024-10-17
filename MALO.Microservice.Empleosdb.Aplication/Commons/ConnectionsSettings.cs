
namespace MALO.Microservice.Empleosdb.Aplication.Commons
{
    public class ConnectionsSettings
    {
        public const string SectionName = "ConnectionStrings";
        public string DefaultConnection { get; init; } = null!;
        public string LoggingConnection { get; init; } = null!;
    }
}
