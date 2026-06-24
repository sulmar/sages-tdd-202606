namespace CoolingSystem;

public class OnCoolingState : ICoolingState
{
    public CoolingState Value => CoolingState.On;

    public void Handle(CoolingSystem context, double temperature)
    {
        if (temperature <= 25)
        {
            context.State = new OffCoolingState();
        }
    }
}