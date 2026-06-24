namespace BoundaryTesting;

public class TemperatureClassifier
{
    public TemperatureStatus Classify(double temperature) => temperature switch
    {
        < 80 => TemperatureStatus.Normal,
        < 100 => TemperatureStatus.Warning,
        _ => TemperatureStatus.Critical
    };
}


// Wzorzec projektowy Adapter (za pomoca metody rozszerzacej)
public static class TemperatureStatusToColorAdapter
{
    public static string ToColor(this TemperatureStatus status) => status switch
    {
        TemperatureStatus.Normal => ColorIdentifier.Green,
        TemperatureStatus.Warning => ColorIdentifier.Orange,
        TemperatureStatus.Critical => ColorIdentifier.Red,
        _ => throw new NotSupportedException(status.ToString())
    };
}

public enum TemperatureStatus
{
    Normal,
    Warning,
    Critical
}


public static class ColorIdentifier
{
    public const string Green = "Green";
    public const string Orange = "Orange";
    public const string Red = "Red";
}