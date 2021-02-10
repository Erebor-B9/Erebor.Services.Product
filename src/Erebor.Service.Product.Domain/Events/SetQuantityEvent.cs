using MediatR;

public class SetQuantityEvent:INotification
{
    public int Quantity { get; set; }

    public SetQuantityEvent(int quantity)
    {
        Quantity = quantity;
    }
}
