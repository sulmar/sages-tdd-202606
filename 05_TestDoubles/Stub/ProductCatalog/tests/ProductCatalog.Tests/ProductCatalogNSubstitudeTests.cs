using NSubstitute;

namespace ProductCatalog.Tests;

public class ProductCatalogNSubstitudeTests
{
    [Fact]
    public void GetProductName_ValidFile_ReturnsProductName()
    {
        // Arrange
        var stub = Substitute.For<IFileReader>();

        stub.ReadAllText(Arg.Any<string>()).Returns("Product 1");
        
        
        var catalog = new ProductCatalog(stub);

        // Act
        var result = catalog.GetProductName();

        // Assert
        Assert.NotEqual(string.Empty, result);
        Assert.Equal("Product 1", result);

    }
}
