namespace BoundaryTesting;

public class TemperatureClassifier
{
    public string Classify(double temperature)
    {
        if (temperature < 80)
        {
            return "Green";
        }

        if (temperature < 100)
        {
            return "Orange";
        }

        return "Red";
    }
}