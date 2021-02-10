using System.Threading.Tasks;
using Erebor.Service.Product.Domain.Entities;

namespace Erebor.Service.Product.Domain.Repositories
{
    public interface IProductRepository
    {
        Task AddProductAsync(Entities.Product product);
        Task DeleteProductAsync(string id);
        Task UpdateProductAsync(Entities.Product product);
    }
}