namespace TestingEvents.Tests;

public class TemperatureMonitorTests
{
    [Fact]
    public void RecordTemperature_BelowThreshold_DoesNotRaiseEvent()
    {
        throw new NotImplementedException();
    }

    [Fact]
    public void RecordTemperature_AtThreshold_DoesNotRaiseEvent()
    {
        throw new NotImplementedException();
    }

    [Fact]
    public void RecordTemperature_AboveThreshold_RaisesTemperatureExceededEvent()
    {
        throw new NotImplementedException();
    }

    [Fact]
    public void RecordTemperature_AboveThreshold_PassesTemperatureInEventArgs()
    {
        throw new NotImplementedException();
    }
}
