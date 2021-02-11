using System;
using System.Threading.Tasks;
using Erebor.Service.Product.Domain.Entities;
using Erebor.Service.Product.Domain.Repositories;
using Erebor.Service.Product.SharedKernel.Interfaces;

namespace Erebor.Service.Product.Core.Domain
{
    public class CreateCategoryCommand:ICommand
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public sealed class CreateCategoryCommandHandler : ICommandHandler<CreateCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;

        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Result> Handle(CreateCategoryCommand command)
        {
            await _categoryRepository.AddCategoryAsync(Category.CreateCategory(command.CategoryName, command.Description));
            return Result.Successful;
        }
    }
}