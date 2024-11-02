

namespace MALO.Microservice.Empresas.Infraestructure.Services
{
    public interface IMessage
    {
        Task SendEmail(string email, string subject, string body);
    }
}
