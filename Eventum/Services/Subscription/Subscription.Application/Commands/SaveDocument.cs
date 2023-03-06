using MediatR;

namespace Subscription.Application.Commands
{
    public class SaveDocument : IRequest
    {
        public string DocumentPath { get; set; }
    }
}
