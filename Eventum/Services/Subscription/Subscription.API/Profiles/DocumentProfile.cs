using AutoMapper;
using EventBus.Messages.Events;
using Subscription.API.Models;
using Subscription.Application.Commands;
using Subscription.Application.Models;

namespace Subscription.API.Profiles
{
    public class DocumentProfile: Profile
    {
        public DocumentProfile()
        {
            CreateMap<SubscriptionRequest, PdfGenerationRequested>();
            CreateMap<PdfContent, PdfGenerationRequested>().ReverseMap();
            CreateMap<PdfGenerated,SaveDocument>().ReverseMap();
        }
    }
}
