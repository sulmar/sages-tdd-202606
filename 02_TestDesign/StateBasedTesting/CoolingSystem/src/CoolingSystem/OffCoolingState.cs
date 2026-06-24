namespace CoolingSystem;

public class OffCoolingState : ICoolingState
{
    public CoolingState Value => CoolingState.Off;

    public void Handle(CoolingSystem context, double temperature)
    {
        if (temperature >= 30)
        {
            context.State =new OnCoolingState();            
        }
    }
}
