namespace Erebor.Service.Product.Domain.Events
{
    public class SetDescriptionEvent: INotificationEvent
    {
        public string Description { get; set; }

        public SetDescriptionEvent(string description)
        {
            Description = description;
        }
    }
}
