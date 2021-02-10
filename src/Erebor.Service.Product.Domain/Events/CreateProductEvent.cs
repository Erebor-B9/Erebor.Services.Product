using MediatR;

namespace Erebor.Service.Product.Domain.Events
{
    public class CreateProductEvent:INotificationEvent
    {
        public CreateProductEvent(string categoryId, string productName, string description, decimal price,
            int quantity, bool isActive)
        {
            CategoryId = categoryId;
            ProductName = productName;
            Description = description;
            Price = price;
            Quantity = quantity;
            IsActive = isActive;
        }

        public string CategoryId { get; }
        public string ProductName { get; }
        public string Description { get; }
        public decimal Price { get; }
        public int Quantity { get; }
        public bool IsActive { get; }
    }
}