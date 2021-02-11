using System.Threading.Tasks;
using Erebor.Service.Product.Core.Interface;
using Erebor.Service.Product.Domain.Entities;
using Erebor.Service.Product.Domain.Repositories;

namespace Erebor.Service.Product.Infrastructure.Repository
{
    public class CategoryRepository:ICategoryRepository
    {
        private readonly IApplicationContext _context;

        public CategoryRepository(IApplicationContext context)
        {
            _context = context;
        }

        public async Task AddCategoryAsync(Category category)
        {
           await _context.Category.InsertOneAsync(category);
        }
    }
}