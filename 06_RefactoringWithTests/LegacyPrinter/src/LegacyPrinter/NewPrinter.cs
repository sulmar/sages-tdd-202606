namespace LegacyPrinter;

public class NewPrinter
{
    public void PrintDocument(string document, int copies)
    {
        for (int i = 0; i < copies; i++)
        {
            Console.WriteLine(document);
        }
    }
}
