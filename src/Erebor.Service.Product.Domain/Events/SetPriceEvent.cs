namespace Erebor.Service.Product.Domain.Events
{
    public class SetPriceEvent: INotificationEvent
    {
        public decimal Price{ get; set; }
        public SetPriceEvent(decimal price)
        {
            Price = price;
        }
    }
}