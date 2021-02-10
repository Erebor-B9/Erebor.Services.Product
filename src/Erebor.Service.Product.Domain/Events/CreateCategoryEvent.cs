using System;
using MediatR;

public class CreateCategoryEvent:INotification
{
    public string CategoryName { get; set; }
    public string Description { get; set; }
    public DateTime CreatedDate { get; set; }
    public CreateCategoryEvent(string categoryName, string description, DateTime createdDate)
    {
        CategoryName = categoryName;
        Description = description;
        CreatedDate = createdDate;
    }
}