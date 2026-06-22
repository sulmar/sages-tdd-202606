namespace CreateOrder;

public class OrderController
{
    public ActionResult Post(Order order)
    {
        var gmailClient = new GmailApiClient();

        gmailClient.Send("Order created");

        return new CreatedResult<Order>(order);
    }
}
