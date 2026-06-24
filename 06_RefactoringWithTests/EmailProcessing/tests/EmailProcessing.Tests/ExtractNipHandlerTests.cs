namespace EmailProcessing.Tests;

public class ExtractNipHandlerTests
{
    private readonly ExtractNipHandler handler;
    private readonly EmailContext context = new();

    public ExtractNipHandlerTests()
    {
        handler = new ExtractNipHandler();
    }

    [Fact]
    public void Handle_ValidNip_SetNip()
    {
        // Arrange
        context.Email = new Email(
            From: "a",
            Body: "NIP: 9876543210",
            Attachments: []);


        // Act
        handler.Handle(context);

        // Assert
        Assert.Equal("9876543210", context.Nip);
    }

    [Fact]
    public void Hander_InvalidNip_SetNipToNull()
    {
        // Arrange
        context.Email = new Email(
            From: "a",
            Body: "NIP: 123",
            Attachments: []);


        // Act
        handler.Handle(context);

        // Assert
        Assert.Null(context.Nip);
    }

}
