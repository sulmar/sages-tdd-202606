namespace LegacyPrinter.Tests;

// Fabryka (Factory)
public class PrinterFactory
{
    public static IPrinter CreatePrinter(bool useLegacy = false) => useLegacy ? CreateLegacyPrinter() : CreateNewPrinter();

    // Metody fabrykujace (Method Fabric)
    public static IPrinter CreateLegacyPrinter() => new LegacyPrinterAdapter(new LegacyPrinter());
    public static IPrinter CreateNewPrinter() => new NewPrinter();
}

public class NewPrinterTests : IDisposable
{
    private readonly IPrinter printer;
    private readonly StringWriter writer = new();
    private readonly TextWriter originalOut = Console.Out;

    public NewPrinterTests()
    {
        Console.SetOut(writer);

        printer = PrinterFactory.CreateNewPrinter();                        
    }

    public void Dispose()
    {
        Console.SetOut(originalOut);
    }
  
    [Fact]
    public void PrintDocument_SingleCopy_PrintsDocumentOnce()
    {

        printer.PrintDocument("Invoice #42", copies: 1);

        Assert.Equal($"Invoice #42{Environment.NewLine}", writer.ToString());

    }

    [Fact]
    public void PrintDocument_MultipleCopies_PrintsDocumentForEachCopy()
    {

        printer.PrintDocument("Invoice #42", copies: 3);

        string expected = string.Join("", Enumerable.Repeat($"Invoice #42{Environment.NewLine}", 3));
        Assert.Equal(expected, writer.ToString());

    }

    [Fact]
    public void PrintDocument_ZeroCopies_PrintsNothing()
    {

        printer.PrintDocument("Invoice #42", copies: 0);

        Assert.Equal(string.Empty, writer.ToString());

    }




}

