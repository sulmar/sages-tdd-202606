namespace CreateOrder;


public interface IMessageClient
{
    void Send(string message);
}

public class OrderController(IMessageClient client)
{
    public ActionResult Post(Order order)
    {        
        client.Send("Order created");

        return new CreatedResult<Order>(order);
    }
}
