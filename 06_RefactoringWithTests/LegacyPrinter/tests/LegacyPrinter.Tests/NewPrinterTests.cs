namespace LegacyPrinter.Tests;

public class NewPrinterTests
{
    [Fact]
    public void PrintDocument_SingleCopy_PrintsDocumentOnce()
    {
        using StringWriter writer = new();
        TextWriter originalOut = Console.Out;
        Console.SetOut(writer);

        try
        {
            var printer = new NewPrinter();
            printer.PrintDocument("Invoice #42", copies: 1);

            Assert.Equal($"Invoice #42{Environment.NewLine}", writer.ToString());
        }
        finally
        {
            Console.SetOut(originalOut);
        }
    }

    [Fact]
    public void PrintDocument_MultipleCopies_PrintsDocumentForEachCopy()
    {
        using StringWriter writer = new();
        TextWriter originalOut = Console.Out;
        Console.SetOut(writer);

        try
        {
            var printer = new NewPrinter();
            printer.PrintDocument("Invoice #42", copies: 3);

            string expected = string.Join("", Enumerable.Repeat($"Invoice #42{Environment.NewLine}", 3));
            Assert.Equal(expected, writer.ToString());
        }
        finally
        {
            Console.SetOut(originalOut);
        }
    }

    [Fact]
    public void PrintDocument_ZeroCopies_PrintsNothing()
    {
        using StringWriter writer = new();
        TextWriter originalOut = Console.Out;
        Console.SetOut(writer);

        try
        {
            var printer = new NewPrinter();
            printer.PrintDocument("Invoice #42", copies: 0);

            Assert.Equal(string.Empty, writer.ToString());
        }
        finally
        {
            Console.SetOut(originalOut);
        }
    }
}
