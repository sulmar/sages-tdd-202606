namespace CoolingSystem;

public class CoolingSystem
{
    public CoolingState State { get; private set; }

    public void Update(double temperature)
    {
        if (State == CoolingState.Off &&
            temperature >= 30)
        {
            State = CoolingState.On;
            return;
        }

        if (State == CoolingState.On &&
            temperature <= 25)
        {
            State = CoolingState.Off;
        }
    }
}