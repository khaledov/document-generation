using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using Subscription.Application.Persistance;

namespace Subscription.Infrastructure.Persistence
{
    public class DocumentRepository : IDocumentRepository
    {
        readonly IConfiguration _configuration;
        public DocumentRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task SaveDocument(string fielPath)
        {
            var client = new MongoClient(_configuration.GetSection("DatabaseSettings:ConnectionString").Value);
            var database = client.GetDatabase(_configuration.GetSection("DatabaseSettings:DatabaseName").Value);

            var gridFsBucket = new GridFSBucket(database);
            using var stream = File.OpenRead($"subscription_uploads/{fielPath}.pdf");
          
            var task =await Task.Run(() => gridFsBucket.UploadFromStreamAsync(fielPath, stream));
            
        }
    }
}
