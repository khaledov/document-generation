namespace Subscription.Application.Persistance
{
    public interface IDocumentRepository
    {
        Task SaveDocument(string fielPath);
    }
}
