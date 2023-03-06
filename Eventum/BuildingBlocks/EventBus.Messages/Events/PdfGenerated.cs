namespace EventBus.Messages.Events
{
    public class PdfGenerated : IntegrationBaseEvent
    {
        public string? DocumentName { get; set; }
    }
}
