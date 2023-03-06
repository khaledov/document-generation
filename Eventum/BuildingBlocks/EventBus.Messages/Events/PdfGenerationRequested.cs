namespace EventBus.Messages.Events
{
    public class PdfGenerationRequested : IntegrationBaseEvent
    {
        public int CustomerNumber { get; set; }


        public Guid DocumentNumber { get; set; }


        public string? DocumentText { get; set; }
    }
}
