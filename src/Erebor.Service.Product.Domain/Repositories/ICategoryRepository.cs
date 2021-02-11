using System.Threading.Tasks;
using Erebor.Service.Product.Domain.Entities;

namespace Erebor.Service.Product.Domain.Repositories
{
    public interface ICategoryRepository
    {
        Task AddCategoryAsync(Category category);
    }
}