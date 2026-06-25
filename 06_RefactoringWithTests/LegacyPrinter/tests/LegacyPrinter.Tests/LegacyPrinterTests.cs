using NSubstitute;

namespace LegacyPrinter.Tests;

public class LegacyPrinterTests
{
    [Theory]
    [InlineData(5)]
    [InlineData(0)]
    public void PrintDocument_NumberOfCopies_PrintedAllCopies(int copies)
    {
        //Arrange 
        var mock = Substitute.For<LegacyPrinter>();
        var adapter = new LegacyPrinterAdapter(mock);
        //Act
        adapter.PrintDocument("", copies);
        //Assert
        mock.Received(copies).PrintDocument(Arg.Any<string>());
    }
}

