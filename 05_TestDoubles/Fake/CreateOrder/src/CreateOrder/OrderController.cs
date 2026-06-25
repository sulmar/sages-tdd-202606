namespace CreateOrder;

public interface IMessageClient
{
    void Send(string messsage);
}

public class OrderController
{
    private readonly IMessageClient messageClient;
    public OrderController(IMessageClient messageClient)
    {
        this.messageClient = messageClient;
    }

    public OrderController()
        : this(new GmailApiClient())
    {        
    }

    public ActionResult Post(Order order)
    {
        messageClient.Send("Order created");

        return new CreatedResult<Order>(order);
    }
}
