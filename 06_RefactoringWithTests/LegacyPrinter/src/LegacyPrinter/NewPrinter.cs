namespace LegacyPrinter;

public interface IPrinter
{
    void PrintDocument(string document, int copies);
}

public class NewPrinter : IPrinter
{
    public void PrintDocument(string document, int copies)
    {
        for (int i = 0; i < copies; i++)
        {
            Console.WriteLine(document);
        }
    }
}
