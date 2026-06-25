namespace CreateOrder;

public class GmailApiClient : IMessageClient
{
    public void Send(string message)
    {
        throw new InvalidOperationException("Gmail API requires network access.");
    }
}
