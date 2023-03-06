namespace EventBus.Messages.Events
{
    public class PdfGenerated : IntegrationBaseEvent
    {
        public string? DocumentPath { get; set; }
    }
}
