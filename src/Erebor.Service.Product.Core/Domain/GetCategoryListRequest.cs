using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Erebor.Service.Product.Domain.Entities;
using Erebor.Service.Product.Domain.Repositories;
using MediatR;

namespace Erebor.Service.Product.Core.Domain
{
    public class GetCategoryListRequest : IRequest<List<Category>>
    {
        public string Name { get; set; }
    }
    public sealed class GetCategoryListRequestHandler : IRequestHandler<GetCategoryListRequest, List<Category>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetCategoryListRequestHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<Category>> Handle(GetCategoryListRequest request, CancellationToken cancellationToken)
        {
            return await _categoryRepository.GetCategoryListAsync(x => x.CategoryName.Contains(request.Name));
        }
    }
}