namespace TestingEvents;

public class TemperatureMonitor
{
    public event EventHandler<TemperatureExceededEventArgs>? TemperatureExceeded;

    public double Threshold { get; }

    public TemperatureMonitor(double threshold)
    {
        Threshold = threshold;
    }

    public void RecordTemperature(double temperature)
    {
        if (temperature > Threshold)
        {
            TemperatureExceeded?.Invoke(this, new TemperatureExceededEventArgs(temperature));
        }
    }
}

public class TemperatureExceededEventArgs : EventArgs
{
    public double Temperature { get; }

    public TemperatureExceededEventArgs(double temperature)
    {
        Temperature = temperature;
    }
}
