namespace ObjectEquality;

public class GpsLocation
{
    public double Latitude { get; }
    public double Longitude { get; }

    public GpsLocation(double latitude, double longitude)
    {
        Latitude = latitude;
        Longitude = longitude;
    }
}
