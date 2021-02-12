using System;
using System.Threading;
using System.Threading.Tasks;
using Erebor.Service.Product.Core.Interface;
using Erebor.Service.Product.Domain.Repositories;
using MediatR;


namespace Erebor.Service.Product.Core.Domain
{
    public class CreateProductCommand : IRequest
    {
        public string Id { get; set; }
        public string CategoryId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public bool IsActive { get; set; }
        
    }

    public sealed class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
    {
        public readonly IProductRepository _productRepository;
        public CreateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        
        public async Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = Product.Domain.Entities.Product.CreateProduct(request.CategoryId, request.ProductName, request.Description
                , request.Price, request.Quantity, request.IsActive);
            await _productRepository.AddProductAsync(product);
            return Unit.Value;
        }
    }
}