using MediatR;

public class SetCategoryNameEvent:INotification
{
    public string CategoryName { get; set; }

    public SetCategoryNameEvent(string categoryName)
    {
        CategoryName = categoryName;
    }
}
