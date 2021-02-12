using System;
using System.Threading;
using System.Threading.Tasks;
using Erebor.Service.Product.Domain.Entities;
using Erebor.Service.Product.Domain.Repositories;
using MediatR;

namespace Erebor.Service.Product.Core.Domain
{
    public class UpdateCategoryCommand:IRequest
    {
        public string Id { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public sealed class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;
        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            await _categoryRepository.UpdateCategoryAsync(Category.CreateCategory(request.Id,request.CategoryName, request.Description));
            return Unit.Value;
        }
    }
}