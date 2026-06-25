namespace CreateOrder;

public interface IMessageClient
{
    void Send(string message);
}
 

public class OrderController
{
    private readonly IMessageClient _messageClient;

    public OrderController()
        : this(new GmailApiClient())
    {
        
    }

    public OrderController(IMessageClient messageClient)
    {
        _messageClient = messageClient;
    }

    public ActionResult Post(Order order)
    {
        // var gmailClient = new GmailApiClient();

        _messageClient.Send("Order created");

        return new CreatedResult<Order>(order);
    }
}
