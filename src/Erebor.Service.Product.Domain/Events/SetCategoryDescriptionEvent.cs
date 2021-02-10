namespace Erebor.Service.Product.Domain.Events
{
    public class SetCategoryDescriptionEvent: INotificationEvent
    {
        public string Description { get; set; }

        public SetCategoryDescriptionEvent(string description)
        {
            Description = description;
        }
    }
}
