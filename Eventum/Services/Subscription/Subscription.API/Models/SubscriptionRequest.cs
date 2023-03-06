namespace Subscription.API.Models
{
    public class SubscriptionRequest
    {
        public int CustomerNumber { get; set; }
        public Guid DocumentNumber { get; set; }
        public string? DocumentText { get; set; }
    }
}
