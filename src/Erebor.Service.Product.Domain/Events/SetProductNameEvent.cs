using MediatR;

namespace Erebor.Service.Product.Domain.Events
{
    public class SetProductNameEvent: INotificationEvent
    {
        public string ProductName { get; set; }

        public SetProductNameEvent(string productName)
        {
            ProductName = productName;
        }
    }
}