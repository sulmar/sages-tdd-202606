namespace EmailProcessing.Tests;

public class WhitelistHandlerTests
{
    private readonly WhitelistHandler handler;    
    private readonly EmailContext context;
    private readonly TestHandler testHandler;

    public WhitelistHandlerTests()
    {
        handler = new WhitelistHandler(new InMemoryWhitelistRepository());
        
        context = new EmailContext();

        testHandler = new TestHandler();

        handler.SetNext(testHandler);
    }

    [Fact]
    public void Handle_SenderNotOnWhitelist_CalledIsFalse()
    {
        // Arrange
        context.Email = new Email(
            From: "unknown@example.com",
            Body: "a",
            Attachments: []);

        // Act
        handler.Handle(context);

        // Assert
        Assert.False(testHandler.Called);
    }

    [Fact]
    public void Process_SenderOnWhitelist_ReturnsTrue()
    {
        // Arrange
        context.Email = new Email(
            From: "trusted@example.com",
            Body: "a",
            Attachments: []);        

        // Act
        handler.Handle(context);

        // Assert
        Assert.True(testHandler.Called);
    }
}
