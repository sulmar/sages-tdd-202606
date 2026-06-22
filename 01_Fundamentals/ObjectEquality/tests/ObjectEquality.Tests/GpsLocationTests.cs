namespace ObjectEquality.Tests;

public class GpsLocationTests
{
    [Fact]
    public void GpsLocation_SameCoordinates_AreEqual()
    {
        var loc1 = new GpsLocation(52.2297, 21.0122);
        var loc2 = new GpsLocation(52.2297, 21.0122);

        Assert.Equal(loc1, loc2);
    }

    [Fact]
    public void GpsLocation_DifferentLatitude_AreNotEqual()
    {
        var loc1 = new GpsLocation(52.2297, 21.0122);
        var loc2 = new GpsLocation(50.0647, 21.0122);

        Assert.NotEqual(loc1, loc2);
    }

    [Fact]
    public void GpsLocation_DifferentLongitude_AreNotEqual()
    {
        var loc1 = new GpsLocation(52.2297, 21.0122);
        var loc2 = new GpsLocation(52.2297, 19.9450);

        Assert.NotEqual(loc1, loc2);
    }
}
