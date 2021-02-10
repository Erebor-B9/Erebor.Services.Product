namespace Erebor.Service.Product.Domain.Events
{
    public class SetCategoryNameEvent: INotificationEvent
    {
        public string CategoryName { get; set; }

        public SetCategoryNameEvent(string categoryName)
        {
            CategoryName = categoryName;
        }
    }
}
