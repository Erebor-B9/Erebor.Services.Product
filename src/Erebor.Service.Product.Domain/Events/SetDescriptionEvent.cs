using MediatR;

public class SetDescriptionEvent:INotification
{
    public string Description { get; set; }

    public SetDescriptionEvent(string description)
    {
        Description = description;
    }
}
