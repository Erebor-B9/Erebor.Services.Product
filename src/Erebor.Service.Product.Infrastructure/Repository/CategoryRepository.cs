using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Erebor.Service.Product.Core.Interface;
using Erebor.Service.Product.Domain.Entities;
using Erebor.Service.Product.Domain.Repositories;
using MongoDB.Driver;
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

        public  async Task DeleteCategoryAsync(string categoryId)
        {
            await _context.Category.DeleteOneAsync(x => x.Id == categoryId);
        }

        public async Task<Category> GetCategoryAsync(string name = null)
        {
            var category = await _context.Category.FindAsync(x => x.CategoryName == name);
            return await  category.FirstOrDefaultAsync();
        }

        public async Task<List<Category>> GetCategoryListAsync(Expression<Func<Category, bool>> filter = null)
        {
            var categoryList = await _context.Category.FindAsync(filter);
            return await categoryList.ToListAsync();
        }

        public async Task UpdateCategoryAsync(Category category)
        {
           await _context.Category.ReplaceOneAsync(x => x.Id == category.Id, category);
        }
    }
}