using AutoMapper;
using EventBus.Messages.Events;
using MassTransit;
using MediatR;
using Subscription.Application.Commands;

namespace Subscription.API.EventBusConsumers
{
    public class PdfGeneratedConsumer : IConsumer<PdfGenerated>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IPublishEndpoint _publishEndpoint;
        public PdfGeneratedConsumer(IMediator mediator, IMapper mapper, IPublishEndpoint publishEndpoint)
        {
            _mediator = mediator;
            _mapper = mapper;
            _publishEndpoint = publishEndpoint;
        }
        public async Task Consume(ConsumeContext<PdfGenerated> context)
        {
            var command= _mapper.Map<SaveDocument>(context.Message);
           await _mediator.Send<SaveDocument>(command);
           await _publishEndpoint.Publish(new ClientSuccessfullySubscriped());
        }
    }
}
