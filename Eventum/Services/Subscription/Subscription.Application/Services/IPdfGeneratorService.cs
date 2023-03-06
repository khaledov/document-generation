using Subscription.Application.Models;

namespace Subscription.Application.Services
{
    public interface IPdfGeneratorService
    {
        Task GeneratePdf(PdfContent content);
    }
}
