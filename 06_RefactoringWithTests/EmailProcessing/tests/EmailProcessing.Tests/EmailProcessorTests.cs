namespace EmailProcessing.Tests;

public class EmailProcessorTests
{
    private readonly EmailProcessor _processor = new();

    [Fact]
    public void Process_SenderNotOnWhitelist_DoesNotCreateQuote()
    {
        var email = new Email(
            From: "unknown@example.com",
            Body: "NIP: 1234567890",
            Attachments: ["spec.pdf"]);

        _processor.Process(email);

        Assert.Empty(_processor.CreatedQuotes);
    }

    [Fact]
    public void Process_WhitelistedSenderWithoutNip_DoesNotCreateQuote()
    {
        var email = new Email(
            From: "trusted@example.com",
            Body: "Proszę o wycenę",
            Attachments: ["spec.pdf"]);

        _processor.Process(email);

        Assert.Empty(_processor.CreatedQuotes);
    }

    [Fact]
    public void Process_CustomerNotInDatabase_DoesNotCreateQuote()
    {
        var email = new Email(
            From: "trusted@example.com",
            Body: "NIP: 9876543210",
            Attachments: []);

        _processor.Process(email);

        Assert.Empty(_processor.CreatedQuotes);
    }

    [Fact]
    public void Process_ValidEmail_CreatesQuote()
    {
        var email = new Email(
            From: "trusted@example.com",
            Body: "NIP: 1234567890",
            Attachments: []);

        _processor.Process(email);

        Assert.Single(_processor.CreatedQuotes);
        Assert.Equal(email, _processor.CreatedQuotes[0]);
    }
}
