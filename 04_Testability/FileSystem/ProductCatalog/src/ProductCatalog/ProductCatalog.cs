namespace ProductCatalog;

// uwaga na zasade ISP Interface Separation Principle - rozdzielamy interfejsy na mniejsze, bardziej wyspecjalizowane
public interface IFileReader
{
    string ReadAllText(string path);
}

public interface IFileWriter
{
    void WriteAllText(string path, string content);
}

public interface IFileReaderWriter : IFileReader, IFileWriter
{
}

public class RealFileReader : IFileReader
{
    public string ReadAllText(string path) => File.ReadAllText(path);
}

public class RealFileWriter : IFileWriter
{
    public void WriteAllText(string path, string content) => File.WriteAllText(path, content);
}

public class ProductCatalog
{
    private readonly IFileReader _fileReader;
    private readonly IFileWriter _fileWriter;

    public ProductCatalog(IFileReader fileReader, IFileWriter fileWriter)
    {
        _fileReader = fileReader;
        _fileWriter = fileWriter;
    }

    public ProductCatalog()
        : this(new RealFileReader(), new RealFileWriter())
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


    public void SaveProductName(string name)
    {
        if (string.IsNullOrEmpty(name))
            throw new ArgumentException("Product name cannot be null or empty.", nameof(name));

        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Product name cannot be whitespace.", nameof(name));

       _fileWriter.WriteAllText("product.txt", name);
    }
}
}
