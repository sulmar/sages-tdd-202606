namespace SmartHome.Tests;

// Off -> MotionDetected() -> On -> Timeout() -> Dimmed -> Timeout() -> Off

public class SmartLightTests
{
    private readonly SmartLight light = new SmartLight(new SmartLightStateMachine());

    [Fact]
    public void MotionDetected_WhenLightIsOff_ShouldTurnOn()
    {        
        // Act
        light.MotionDetected();

        // Assert
        Assert.Equal(LightState.On, light.State);

    }


    [Fact]
    public void Timeout_WhenLightIsOn_ShouldDimmed()
    {  
        // Arrange     
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
        light.MotionDetected();
        light.Timeout();

        // Act
        light.Timeout();

        // Assert
        Assert.Equal(LightState.Off, light.State);

    }
}
