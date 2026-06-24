namespace ProductCatalog;

public interface IFileReader
{
    string ReadAllText(string path);
}

public class RealFileReader : IFileReader
{
    public string ReadAllText(string path)
    {
        return File.ReadAllText(path);
    }
}

public class ProductCatalog
{
    private readonly IFileReader _fileReader;

    public ProductCatalog(IFileReader fileReader)
    {
        _fileReader = fileReader;
    }

    public ProductCatalog()
        : this(new RealFileReader())
    {
        
    }

    public string GetProductName()
    {
        var content = _fileReader.ReadAllText("product.txt");

        if (string.IsNullOrEmpty(content))
            throw new Exception();

        if (string.IsNullOrWhiteSpace(content))
            throw new Exception();

        return content;
    }
}
