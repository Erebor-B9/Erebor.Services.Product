using Erebor.Service.Product.Core.Interface;
using Erebor.Service.Product.Domain.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Erebor.Service.Product.Infrastructure.Context
{
    public class ApplicationContext : IApplicationContext
    {
        private readonly IMongoDatabase _database;
        public ApplicationContext(IOptions<MongoDbSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            _database = client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<Domain.Entities.Product> Product =>
            _database.GetCollection<Domain.Entities.Product>("Product");

        public IMongoCollection<Domain.Entities.Category> Category => 
            _database.GetCollection<Category>("Category");

       
    }
}