namespace GateConsoleApp.Domain;

public record class Gate(string deviceId, string name)
{
    public bool IsOpened { get; set; }
}
