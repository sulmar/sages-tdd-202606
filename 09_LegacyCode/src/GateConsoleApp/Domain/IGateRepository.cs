namespace GateConsoleApp.Domain;

public interface IGateRepository
{
   Gate Get(string deviceId);
}
