namespace LegacyPrinter;

public class LegacyPrinter
{
    public void PrintDocument(string document)
    {
        Console.WriteLine(document);
    }
}


// Wzorzec Adapter (Adapter) - wariant obiektowy (uzywa referencji)
public class LegacyPrinterAdapter : IPrinter
{
    private readonly LegacyPrinter adaptee;

    public LegacyPrinterAdapter()
        : this(new LegacyPrinter())
    {        
    }

    public LegacyPrinterAdapter(LegacyPrinter adaptee)
    {        
        ArgumentNullException.ThrowIfNull(adaptee);
    
        this.adaptee = adaptee;
    }

    public void PrintDocument(string document, int copies)
    {
        for (int i = 0; i < copies; i++)
        {
            adaptee.PrintDocument(document);
        }

       // Parallel.For(0, copies, i => adaptee.PrintDocument(document));
    }
}

// Wzorzec Adapter (Adapter) - wariant klasowy (uzywa dziedziczenia)
public class LegacyPrinterAdapter2 : LegacyPrinter, IPrinter
{
    public void PrintDocument(string document, int copies)
    {
        for (int i = 0; i < copies; i++)
        {
            base.PrintDocument(document);
        }
    }
}