using EventBus.Messages.Events;
using MassTransit;
using Subscription.Application.Services;

namespace Subscription.API.EventBusConsumers
{
    public class ClientSuccessfullySubscripedConsumer : IConsumer<ClientSuccessfullySubscriped>
    {
        private readonly IEmailService _emailService;

        public ClientSuccessfullySubscripedConsumer(IEmailService emailService)
        {
            _emailService = emailService;
        }
        public async Task Consume(ConsumeContext<ClientSuccessfullySubscriped> context)
        {
            await _emailService.SendEmail("Dummy text");
        }
    }
}
