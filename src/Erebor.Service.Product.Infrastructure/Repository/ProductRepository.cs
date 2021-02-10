using System.Threading.Tasks;
using Erebor.Service.Product.Core.Interface;
using Erebor.Service.Product.Domain.Repositories;
using MongoDB.Driver;

namespace Erebor.Service.Product.Infrastructure.Repository
{
    public class ProductRepository:IProductRepository
    {
        public readonly IApplicationContext Context;

        public ProductRepository(IApplicationContext context)
        {
            Context = context;
        }

        public async Task AddProductAsync(Domain.Entities.Product product)
        {
            await Context.Product.InsertOneAsync(product);
           
        }

        public async Task DeleteProductAsync(string id)
        {
            await Context.Product.DeleteOneAsync(x => x.Id == id);
        }

        public async Task UpdateProductAsync(Domain.Entities.Product product)
        {
            await Context.Product.ReplaceOneAsync(x => x.Id == product.Id, product);
        }
    }
}