using System.IO.Pipelines;

namespace ProductCatalog.Tests;

public class FakeFileReader : IFileReader
{
    public string ReadAllText(string path) => "Product Name";
}

public class FakeEmptyFileReader : IFileReader
{
    public string ReadAllText(string path) => string.Empty;
}

public class FakeMissingFileReader : IFileReader
{
    public string ReadAllText(string path) => throw new FileNotFoundException();
}

public class FakeWhitespaceFileReader : IFileReader
{
    public string ReadAllText(string path) => "   ";
}

public class ProductCatalogTests
{
    // Leniwa inicjalizacja
    private Lazy<ProductCatalog> _lazyCatalog => new Lazy<ProductCatalog>(() => new ProductCatalog(fileReader));
    private ProductCatalog catalog => _lazyCatalog.Value;

    private IFileReader fileReader;
    

    [Fact]
    public void GetProductName_ValidFile_ReturnsProductName()
    {
        // Arrange
        //  ProductCatalog catalog = new ProductCatalog(new FakeFileReader());

        fileReader = new FakeFileReader();        

        // Act
        var result = catalog.GetProductName();

        // Assert
        Assert.Equal("Product Name", result);
    }

    [Fact]
    public void GetProductName_EmptyFile_ThrowsException()
    {
        // Arrange
        // ProductCatalog catalog = new ProductCatalog(new FakeEmptyFileReader());

        fileReader = new FakeEmptyFileReader();

        // Act && Assert
        Assert.Throws<Exception>(()=> catalog.GetProductName());
    }

    [Fact]
    public void GetProductName_WhitespaceFile_ThrowsException()
    {
        // Arrange
        //  ProductCatalog catalog = new ProductCatalog(new FakeWhitespaceFileReader());
        fileReader = new FakeWhitespaceFileReader();

        // Act && Assert
        Assert.Throws<Exception>(() => catalog.GetProductName()); 
    }

    [Fact]
    public void GetProductName_FileDoesNotExist_ThrowsFileNotFoundException()
    {
        // Arrange
        // ProductCatalog catalog = new ProductCatalog(new FakeMissingFileReader());
        fileReader = new FakeMissingFileReader();

        // Act && Assert
        Assert.Throws<FileNotFoundException>(() => catalog.GetProductName());
    }
}
