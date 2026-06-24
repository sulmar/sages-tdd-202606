namespace BoundaryTesting.Tests;

public class TemperatureClassifierTests
{
    [Theory]
    [InlineData(25, ColorIdentifier.Green)]
    [InlineData(79, ColorIdentifier.Green)]
    [InlineData(80, ColorIdentifier.Orange)]
    [InlineData(99, ColorIdentifier.Orange)]
    [InlineData(100, ColorIdentifier.Red)]
    [InlineData(120, ColorIdentifier.Red)]
    public void Classify_ForGivenTemperature_ShouldReturnExpectedColor(double temperature, string expectedResult)
    {
        // Arrange 
        var classifier = new TemperatureClassifier();        

        // Act 
        var result = classifier.Classify(temperature);

        // Assert 
        Assert.Equal(expectedResult, result.ToColor());
    }

    [Theory]
    [InlineData(25, TemperatureStatus.Normal)]
    [InlineData(79, TemperatureStatus.Normal)]
    [InlineData(80, TemperatureStatus.Warning)]
    [InlineData(99, TemperatureStatus.Warning)]
    [InlineData(100, TemperatureStatus.Critical)]
    [InlineData(120, TemperatureStatus.Critical)]
    public void Classify_ForGivenTemperature_ShouldReturnExpectedTemperatureStatus(double temperature, TemperatureStatus expectedResult)
    {
        // Arrange 
        var classifier = new TemperatureClassifier();

        // Act 
        var result = classifier.Classify(temperature);

        // Assert 
        Assert.Equal(expectedResult, result);
    }
    
}


