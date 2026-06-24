using Stateless;

namespace SmartHome;

// dotnet add package Stateless

public class SmartLight
{
    public LightState State => machine.State;

    private readonly StateMachine<LightState, LightTrigger> machine;

    private void SendEmail()
    {
        Console.WriteLine( "Send email");
    }

    public string Graph => Stateless.Graph.MermaidGraph.Format(machine.GetInfo());

    public SmartLight()
    {
        // FSM (Finite State Machine)
        machine = new StateMachine<LightState, LightTrigger>(LightState.Off);

        machine.Configure(LightState.Off)
            .Permit(LightTrigger.MotionDetected, LightState.On);

        machine.Configure(LightState.On)
            .OnEntry( SendEmail)
            .Permit(LightTrigger.Timeout, LightState.Dimmed)            ;

        machine.Configure(LightState.Dimmed)
            .Permit(LightTrigger.Timeout, LightState.Off);


        System.Diagnostics.Debug.WriteLine(Graph);

    }

    public void MotionDetected() => machine.Fire(LightTrigger.MotionDetected);

    public void Timeout() => machine.Fire(LightTrigger.Timeout);
}

// Off -> MotionDetected() -> On -> Timeout() -> Dimmed -> Timeout() -> Off


public enum LightState
{
    Off,
    On,
    Dimmed
}

public enum LightTrigger
{
    MotionDetected,
    Timeout
}
