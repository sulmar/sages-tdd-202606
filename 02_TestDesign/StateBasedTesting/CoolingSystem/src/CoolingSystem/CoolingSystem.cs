namespace CoolingSystem;

public class CoolingSystem
{
    public ICoolingState State { get; internal set; }

    public CoolingSystem()
    {
        State = new OffCoolingState(); // Initial state
    }

    public void Update(double temperature)
    {
        State.Handle(this, temperature);
    }
}
