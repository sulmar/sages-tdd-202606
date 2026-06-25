using Moq;

namespace ProductCatalog.Tests;

public class ProductCatalogMoqTests
{
    [Fact]
    public void GetProductName_ValidFile_ReturnsProductName()
    {
        // Arrange
        var mock = new Mock<IFileReader>();
         
        //mock.Setup(x => x.ReadAllText("product.txt")) // konfigure metode dla dla wywolania product.txt
        //    .Returns("Product 1");

        mock.Setup(x => x.ReadAllText(It.IsAny<string>())) // konfiguruje metode dla dowolnego ciagu tekstowego
            .Returns("Product 1");

        IFileReader stub = mock.Object;
        var catalog = new ProductCatalog(stub);

        // Act
        var result = catalog.GetProductName();

        // Assert
        Assert.NotEqual(string.Empty, result);
        Assert.Equal("Product 1", result);

    }
}
