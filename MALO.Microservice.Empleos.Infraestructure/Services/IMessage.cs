namespace MALO.Microservice.Empleos.Infraestructure.Services
{
    public interface IMessage
    {
        Task SendEmail(string email, Guid token);
    }
}
