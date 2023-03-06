namespace Subscription.Application.Services
{
    public interface IEmailService
    {
        Task SendEmail(string email);
    }
}
