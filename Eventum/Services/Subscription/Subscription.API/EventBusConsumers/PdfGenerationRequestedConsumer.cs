using AutoMapper;
using EventBus.Messages.Events;
using MassTransit;
using Subscription.Application.Models;
using Subscription.Application.Services;

namespace Subscription.API.EventBusConsumers
{
    public class PdfGenerationRequestedConsumer : IConsumer<PdfGenerationRequested>
    {
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly IMapper _mapper;
        readonly IPdfGeneratorService _pdfGeneratorService;
        private readonly ILogger<PdfGenerationRequestedConsumer> _logger;
        public PdfGenerationRequestedConsumer(IPublishEndpoint publishEndpoint,
            IPdfGeneratorService pdfGeneratorService,
            IMapper mapper,
            ILogger<PdfGenerationRequestedConsumer> logger)
        {
            _mapper = mapper;
            _pdfGeneratorService = pdfGeneratorService;
            _publishEndpoint = publishEndpoint ?? throw new ArgumentNullException(nameof(publishEndpoint));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task Consume(ConsumeContext<PdfGenerationRequested> context)
        {


            var content = _mapper.Map<PdfContent>(context.Message);
            await _pdfGeneratorService.GeneratePdf(content);
           
            await _publishEndpoint.Publish(new PdfGenerated { DocumentName = $"{context.Message.DocumentNumber}.pdf" });
            _logger.LogInformation($"PdfGenerationRequested consumed successfully. Created File Name : {context.Message.DocumentNumber}.pdf");

        }
    }
}
