namespace BomProcessing.Tests;

public class BomProcessorTests
{
    private readonly BomProcessor _processor = new();

    [Fact]
    public void CalculateCost_Profile_ReturnsLengthTimesRate()
    {
        var items = new BomItem[] { new Profile("P1", 2) };

        decimal result = _processor.CalculateCost(items);

        Assert.Equal(200, result);
    }

    [Fact]
    public void CalculateCost_Column_ReturnsHeightTimesRate()
    {
        var items = new BomItem[] { new Column("C1", 3) };

        decimal result = _processor.CalculateCost(items);

        Assert.Equal(450, result);
    }

    [Fact]
    public void CalculateCost_LedStrip_ReturnsLengthTimesRate()
    {
        var items = new BomItem[] { new LedStrip("L1", 5) };

        decimal result = _processor.CalculateCost(items);

        Assert.Equal(200, result);
    }

    [Fact]
    public void CalculateCost_MixedItems_ReturnsSumOfAllCosts()
    {
        var items = new BomItem[]
        {
            new Profile("P1", 2),
            new Column("C1", 3),
            new LedStrip("L1", 5)
        };

        decimal result = _processor.CalculateCost(items);

        Assert.Equal(850, result);
    }

    [Fact]
    public void CalculateWeight_Profile_ReturnsLengthTimesWeight()
    {
        var items = new BomItem[] { new Profile("P1", 2) };

        decimal result = _processor.CalculateWeight(items);

        Assert.Equal(5.0m, result);
    }

    [Fact]
    public void CalculateWeight_Column_ReturnsHeightTimesWeight()
    {
        var items = new BomItem[] { new Column("C1", 3) };

        decimal result = _processor.CalculateWeight(items);

        Assert.Equal(12.0m, result);
    }

    [Fact]
    public void CalculateWeight_LedStrip_ReturnsLengthTimesWeight()
    {
        var items = new BomItem[] { new LedStrip("L1", 5) };

        decimal result = _processor.CalculateWeight(items);

        Assert.Equal(1.0m, result);
    }

    [Fact]
    public void CalculateWeight_MixedItems_ReturnsSumOfAllWeights()
    {
        var items = new BomItem[]
        {
            new Profile("P1", 2),
            new Column("C1", 3),
            new LedStrip("L1", 5)
        };

        decimal result = _processor.CalculateWeight(items);

        Assert.Equal(18.0m, result);
    }
}
