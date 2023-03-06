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
                 try
                 {
                     //var Renderer = new ChromePdfRenderer();
                    
                     File.WriteAllText($"subscription_uploads/{content.DocumentNumber}.pdf", content.DocumentText);
                     Thread.Sleep(3000);
                     //Renderer.RenderHtmlAsPdf($"Hello {content.CustomerNumber} - {content.DocumentNumber}...\n{content.DocumentText}")
                     //.SaveAs($"subscription_uploads/{content.DocumentNumber}.pdf");
                 }
                 catch (Exception ex)
                 {

                    Console.WriteLine(ex);
                 }

               
             });
             
        }
    }
}
