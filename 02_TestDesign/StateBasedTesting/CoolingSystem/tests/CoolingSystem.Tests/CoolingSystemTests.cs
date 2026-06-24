namespace CoolingSystem.Tests;

public class CoolingSystemTests
{
    public readonly CoolingSystem coolingSystem = new();
    //Przykłady
    //Stan początkowy Temperatura Stan końcowy
    //Off	20°C Off
    //Off	29°C Off
    //Off	30°C On
    //On	29°C On
    //On	28°C On
    //On	26°C On
    //On	25°C Off
    [Theory]
    [InlineData(CoolingState.Off, 20, CoolingState.Off)]
    [InlineData(CoolingState.Off, 29, CoolingState.Off)]
    [InlineData(CoolingState.Off, 30, CoolingState.On)]
    [InlineData(CoolingState.On, 29, CoolingState.On)]
    [InlineData(CoolingState.On, 28, CoolingState.On)]
    [InlineData(CoolingState.On, 26, CoolingState.On)]
    [InlineData(CoolingState.On, 25, CoolingState.Off)]
    public void Test1(CoolingState start, double temperature, CoolingState end)
    {
        // Arrange
        coolingSystem.State = start;
        // Act
        coolingSystem.Update(temperature);
        // Assert
        Assert.True(coolingSystem.State == end);
    }

    

}