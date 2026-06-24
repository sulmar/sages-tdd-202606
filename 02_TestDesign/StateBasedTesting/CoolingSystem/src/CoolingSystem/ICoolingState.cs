namespace CoolingSystem;

public interface ICoolingState
{
    CoolingState Value { get; }
    void Handle(CoolingSystem context, double temperature);
}
