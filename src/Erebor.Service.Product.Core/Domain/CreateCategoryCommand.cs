using System;
using System.Threading;
using System.Threading.Tasks;
using Erebor.Service.Product.Domain.Entities;
using Erebor.Service.Product.Domain.Repositories;
using MediatR;


namespace Erebor.Service.Product.Core.Domain
{
    public class CreateCategoryCommand:IRequest
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }

    public sealed class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;

        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Unit> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            await _categoryRepository.AddCategoryAsync(Category.CreateCategory(request.CategoryName, request.Description));
            return  Unit.Value;;
        }
    }
}