namespace CreateOrder;


public interface IMessageClient
{
    void Send(string message);
}

public class OrderController(IMessageClient client)
{
    public ActionResult Post(Order order)
    {
        if (order.Id > 0)
            client.Send("Order created!");        
        

        return new CreatedResult<Order>(order);
    }
}