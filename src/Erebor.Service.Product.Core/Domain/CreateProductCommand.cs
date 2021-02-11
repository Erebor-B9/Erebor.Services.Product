using System;
using System.Threading.Tasks;
using Erebor.Service.Product.Core.Interface;
using Erebor.Service.Product.Domain.Repositories;
using Erebor.Service.Product.SharedKernel.Interfaces;

namespace Erebor.Service.Product.Core.Domain
{
    public class CreateProductCommand : ICommand
    {
        public string Id { get; set; }
        public string CategoryId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public bool IsActive { get; set; }
        
    }

    public sealed class CreateProductCommandHandler : ICommandHandler<CreateProductCommand>
    {
        public readonly IProductRepository _productRepository;
        public CreateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Result> Handle(CreateProductCommand command)
        {
            var product = Product.Domain.Entities.Product.CreateProduct(command.CategoryId, command.ProductName, command.Description
                , command.Price, command.Quantity, command.IsActive);
             await _productRepository.AddProductAsync(product);
             return Result.Successful;

        }
    }
}