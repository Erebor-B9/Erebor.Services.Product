using MongoDB.Driver;

namespace Erebor.Service.Product.Core.Interface
{
    public interface IApplicationContext
    {
        IMongoCollection<Product.Domain.Entities.Product> Product { get; }
        IMongoCollection<Product.Domain.Entities.Category> Category { get; }
    }
}