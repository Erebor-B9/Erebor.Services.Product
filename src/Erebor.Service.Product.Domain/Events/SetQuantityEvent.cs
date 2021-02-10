namespace Erebor.Service.Product.Domain.Events
{
    public class SetQuantityEvent : INotificationEvent
    {
        public int Quantity { get; set; }

        public SetQuantityEvent(int quantity)
        {
            Quantity = quantity;
        }
    }
}