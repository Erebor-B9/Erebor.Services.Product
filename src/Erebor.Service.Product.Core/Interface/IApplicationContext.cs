using MongoDB.Driver;

namespace Erebor.Service.Product.Core.Interface
{
    public interface IApplicationContext
    {
        IMongoCollection<Domain.Entities.Product> Product { get; }
        IMongoCollection<Domain.Entities.Category> Category { get; }
    }
}