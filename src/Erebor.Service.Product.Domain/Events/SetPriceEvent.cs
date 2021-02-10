using MediatR;

public class SetPriceEvent:INotification
{
    public decimal Price{ get; set; }
    public SetPriceEvent(decimal price)
    {
        Price = price;
    }
}