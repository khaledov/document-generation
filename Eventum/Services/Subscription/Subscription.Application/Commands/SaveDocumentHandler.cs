using EventBus.Messages.Events;
using MassTransit;
using MediatR;
using Subscription.Application.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscription.Application.Commands
{
    public class SaveDocumentHandler : IRequestHandler<SaveDocument>
    {
        private readonly IPublishEndpoint _publishEndpoint;
        readonly IDocumentRepository _repository;
        public SaveDocumentHandler(IPublishEndpoint publishEndpoint, IDocumentRepository repository)
        {
            _publishEndpoint = publishEndpoint;

            _repository = repository;

        }
        public async Task Handle(SaveDocument request, CancellationToken cancellationToken)
        {
          await  _repository.SaveDocument(request.DocumentPath);
          await  _publishEndpoint.Publish(new ClientSuccessfullySubscriped ());
        }
    }
}
