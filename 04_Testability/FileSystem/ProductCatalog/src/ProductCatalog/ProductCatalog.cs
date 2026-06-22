namespace ProductCatalog;

public class ProductCatalog
{
    public string GetProductName()
    {
        return File.ReadAllText("product.txt");
    }
}
