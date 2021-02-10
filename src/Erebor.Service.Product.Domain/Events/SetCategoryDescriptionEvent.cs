using MediatR;

public class SetCategoryDescriptionEvent:INotification
{
    public string Description { get; set; }

    public SetCategoryDescriptionEvent(string description)
    {
        Description = description;
    }
}
