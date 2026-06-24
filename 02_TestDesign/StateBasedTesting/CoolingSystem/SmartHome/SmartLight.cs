namespace SmartHome;

public class SmartLight
{
    public void MotionDetected()
    {
        // Logic to turn on the light when motion is detected
    }

    public void Timeout()
    {
        // Logic to turn off the light after a certain period of inactivity
    }
}

// Off -> MotionDetected() -> On -> Timeout() -> Off


public enum LightState
{
    Off,
    On
}
