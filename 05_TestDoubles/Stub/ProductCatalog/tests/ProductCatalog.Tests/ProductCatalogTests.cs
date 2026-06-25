namespace ProductCatalog.Tests;


internal class StubFileReader : IFileReader
{
    public string ReadAllText(string fileName) => "Product 1";
}


public class ProductCatalogTests
{
    [Fact]
    public void GetProductName_ValidFile_ReturnsProductName()
    {
        // Arrange
        IFileReader stub = new StubFileReader();
        var catalog = new ProductCatalog(stub);

        // Act
        var result = catalog.GetProductName();

        // Assert
        Assert.NotEqual(string.Empty, result);
        Assert.Equal("Product 1", result);

    }

    [Fact]

    public void GetProductName_EmptyFile_ThrowsException()
    {
        throw new NotImplementedException();
    }

    [Fact]
    public void GetProductName_WhitespaceFile_ThrowsException()
    {
        throw new NotImplementedException();
    }

    [Fact]
    public void GetProductName_FileDoesNotExist_ThrowsException()
    {
        throw new NotImplementedException();
    }
}
