using Stateless;
using System.Reflection.PortableExecutable;

namespace SmartHome;

// dotnet add package Stateless
public class SmartLightStateMachine : StateMachine<LightState, LightTrigger>
{
    private void SendEmail()
    {
        Console.WriteLine("Send email");
    }

    public SmartLightStateMachine(LightState initialState = LightState.Off) : base(initialState)
    {
        this.Configure(LightState.Off)
           .Permit(LightTrigger.MotionDetected, LightState.On);

        this.Configure(LightState.On)
            .OnEntry(()=> SendEmail()) // -> hint: uzyj wzorca mediator aby pozbyc sie zaleznosci
            .Permit(LightTrigger.Timeout, LightState.Dimmed)
            // .PermitIf(LightTrigger.Timeout, LightState.Dimmed, () => true)
            .Ignore(LightTrigger.MotionDetected);

        this.Configure(LightState.Dimmed)
            .Permit(LightTrigger.Timeout, LightState.Off);
    }

    public string Graph => Stateless.Graph.MermaidGraph.Format(this.GetInfo());

}


public class SmartLight
{
    public LightState State => machine.State;

    private readonly StateMachine<LightState, LightTrigger> machine;

  

  
    public SmartLight(StateMachine<LightState, LightTrigger> machine)
    {
        // FSM (Finite State Machine)
        this.machine = machine;

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
