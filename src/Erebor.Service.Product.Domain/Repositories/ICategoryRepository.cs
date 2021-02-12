using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Erebor.Service.Product.Domain.Entities;

namespace Erebor.Service.Product.Domain.Repositories
{
    public interface ICategoryRepository
    {
        Task AddCategoryAsync(Category category);
        Task DeleteCategoryAsync(string categoryId);
        Task UpdateCategoryAsync(Category category);
        Task<Category> GetCategoryAsync(string name = null);
        Task<List<Category>> GetCategoryListAsync(Expression<Func<Category,bool>> filter =null);

    }
}