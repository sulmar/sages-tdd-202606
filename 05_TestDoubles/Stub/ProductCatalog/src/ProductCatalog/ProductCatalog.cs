namespace ProductCatalog;


public interface IFileReader
{
    string ReadAllText(string fileName);
}

public class RealFileReader : IFileReader
{
    public string ReadAllText(string fileName) => File.ReadAllText(fileName);
}

public class ProductCatalog(IFileReader fileReader)
{
    public string GetProductName()
    {
        return fileReader.ReadAllText("product.csv");
    }
}
