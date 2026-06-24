namespace SmartHome.Tests;

// Off -> MotionDetected() -> On -> Timeout() -> Dimmed -> Timeout() -> Off

public class SmartLightTests
{
    [Fact]
    public void MotionDetected_WhenLightIsOff_ShouldTurnOn()
    {
        // Arrange
        var light = new SmartLight();

        // Act
        light.MotionDetected();

        // Assert
        Assert.Equal(LightState.On, light.State);

    }


    [Fact]
    public void Timeout_WhenLightIsOn_ShouldDimmed()
    {  
        // Arrange
        var light = new SmartLight();
        light.MotionDetected();

        // Act
        light.Timeout();

        // Assert
        Assert.Equal(LightState.Dimmed, light.State);

    }

    // Off -> MotionDetected() -> On -> Timeout() -> Dimmed -> Timeout() -> Off

    [Fact]
    public void Timeout_WhenLightIsDimmed_ShouldTurnOff()
    {
        // Arrange
        var light = new SmartLight();
        light.MotionDetected();
        light.Timeout();

        // Act
        light.Timeout();

        // Assert
        Assert.Equal(LightState.Off, light.State);

    }
}
