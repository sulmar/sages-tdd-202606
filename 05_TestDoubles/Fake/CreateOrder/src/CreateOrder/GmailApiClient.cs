namespace CreateOrder;

public class GmailApiClient
{
    public void Send(string message)
    {
        throw new InvalidOperationException("Gmail API requires network access.");
    }
}
