using System;
using Erebor.Service.Product.Domain.Entities.Base;
using Erebor.Service.Product.Domain.Exceptions;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Erebor.Service.Product.Domain.Entities
{
    public class Product : Entity, IAggregateRoot
    {
        protected Product(string categoryId, string productName, string description, decimal price, int quantity, bool isActive)
        {
            CategoryId = categoryId;
            ProductName = productName;
            Description = description;
            Price = price;
            Quantity = quantity;
            IsActive = isActive;
            CreationDate = DateTime.Now;
        }
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; private set; }
        public string CategoryId { get; private set; }
        public string ProductName { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Quantity { get; private set; }
        public bool IsActive { get; private set; }
        public DateTime CreationDate { get;private set; } 

        public Product SetProductName(string productName)
        {
            if (string.IsNullOrEmpty(productName))
            {
                throw new BusinessException("Product Name can not be null or empty");
            }
            ProductName = productName;
            return this;
        }

        public Product SetDescription(string description)
        {
            if (string.IsNullOrEmpty(description))
            {
                throw new BusinessException("Product Description can not be null or empty");
            }

            Description = description;
            return this;
        }

        public Product SetQuantity(int quantity)
        {
            if (quantity<=0)
            {
                 throw new BusinessException("Quantity can not be zero or negative");
            }
            Quantity = quantity;
            return this;
        }

        public Product SetPrice(decimal price)
        {
            if (price<=0)
            {
                throw new BusinessException("Price can not be zero or negative");
            }
            Price = price;
            return this;
        }

        public static Product CreateProduct(string categoryId, string productName, string description, decimal price,
            int quantity, bool isActive)
            => new Product(categoryId, productName, description, price, quantity,isActive);
    }
}