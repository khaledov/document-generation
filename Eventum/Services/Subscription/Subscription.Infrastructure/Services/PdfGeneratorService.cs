using IronPdf;
using Subscription.Application.Models;
using Subscription.Application.Services;

namespace Subscription.Infrastructure.Services
{
    public class PdfGeneratorService : IPdfGeneratorService
    {
        public async Task GeneratePdf(PdfContent content)
        {
            await Task.Run(() =>
             {
                 var Renderer = new ChromePdfRenderer();
                 var path = Path.Combine(Directory.GetCurrentDirectory(), "pdfs");
                 Renderer.RenderHtmlAsPdf($"Hello {content.CustomerNumber} - {content.DocumentNumber}...\n{content.DocumentText}")
                 .SaveAs($"~/{path}/{content.DocumentNumber}.pdf");
             });
             
        }
    }
}
