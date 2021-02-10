﻿using System;
using Erebor.Service.Product.Domain.Entities.Base;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Erebor.Service.Product.Domain.Entities
{
    public class Category:Entity
    {
        public Category(string categoryName, string description)
        {
            CategoryName = categoryName;
            Description = description;
            CreatedDate = DateTime.Now;
            AddEvent(new CreateCategoryEvent(categoryName,description,CreatedDate));
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }

        public Category SetCategoryName(string categoryName)
        {
            CategoryName = categoryName;
            AddEvent(new SetCategoryNameEvent(categoryName));
            return this;
        }

        public Category SetCategoryDescription(string description)
        {
            Description = description;
            AddEvent(new SetCategoryDescriptionEvent(description));
            return this;
        }
        public static Category CreateCategory(string categoryName, string description)
        {
            return new Category(categoryName, description);
        }
    }
}