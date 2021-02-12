using System.Threading;
using System.Threading.Tasks;
using Erebor.Service.Product.Domain.Entities;
using Erebor.Service.Product.Domain.Repositories;
using MediatR;

namespace Erebor.Service.Product.Core.Domain
{
    public class GetCategoryRequest:IRequest<Category>
    {
        public GetCategoryRequest(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }

    public sealed class GetCategoryRequestHandler : IRequestHandler<GetCategoryRequest,Category>
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetCategoryRequestHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Category> Handle(GetCategoryRequest request, CancellationToken cancellationToken)
        {
            return await _categoryRepository.GetCategoryAsync(request.Name);
        }
    }
}