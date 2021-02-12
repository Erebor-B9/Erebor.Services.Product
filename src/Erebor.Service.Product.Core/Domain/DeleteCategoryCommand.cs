using System.Threading;
using System.Threading.Tasks;
using Erebor.Service.Product.Domain.Repositories;
using MediatR;

namespace Erebor.Service.Product.Core.Domain
{
    public class DeleteCategoryCommand : IRequest
    {
        public DeleteCategoryCommand(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
    }

    public sealed class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
    {
        public readonly ICategoryRepository _categoryRepository;

        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            await _categoryRepository.DeleteCategoryAsync(request.Id);
            return Unit.Value;;
        }
    }
}