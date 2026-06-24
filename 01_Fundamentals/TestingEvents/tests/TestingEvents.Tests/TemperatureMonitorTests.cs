using System.Runtime.CompilerServices;

namespace TestingEvents.Tests;

public class TemperatureMonitorTests
{
    private readonly TemperatureMonitor monitor = new TemperatureMonitor(25);

    private bool eventRaised = false;

    public TemperatureMonitorTests()
    {
        monitor.TemperatureExceeded += (_, _) => eventRaised = true;        
    }

    [Fact]
    public void RecordTemperature_BelowThreshold_DoesNotRaiseEvent()
    {                
        // Act
        monitor.RecordTemperature(20);

        // Assert
        Assert.False(eventRaised);
    }

    [Fact]
    public void RecordTemperature_AtThreshold_DoesNotRaiseEvent()
    {                
        // Act
        monitor.RecordTemperature(25);

        // Assert
        Assert.False(eventRaised);
    }

    [Fact]
    public void RecordTemperature_AboveThreshold_RaisesTemperatureExceededEvent()
    {
        // Act
        monitor.RecordTemperature(30);

        // Assert
        Assert.True(eventRaised);
    }

    [Fact]
    public void RecordTemperature_AboveThreshold_PassesTemperatureInEventArgs()
    {
        // Arrange         
        double? recordedTemperature = null;

        monitor.TemperatureExceeded += (_, e) => recordedTemperature = e.Temperature;

        // Act
        monitor.RecordTemperature(30);

        // Assert
        Assert.Equal(30, recordedTemperature);
    }
}
