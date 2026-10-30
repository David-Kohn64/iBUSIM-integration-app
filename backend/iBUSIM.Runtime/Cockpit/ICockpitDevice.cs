namespace iBUSIM.Runtime.Cockpit;

public interface ICockpitDevice //Any class that is a ICockpitDevice (CockpitSimulator.cs or SerialCockpitDevice) must implement these operations 
{
    Task<CockpitControlSnapshot> ConnectAsync(CancellationToken cancellationToken); //Connect to cockpit and return initial snapshot
    IAsyncEnumerable<CockpitControlUpdate> ReadUpdatesAsync(CancellationToken cancellationToken); //Read updates from cockpit and return enumerable CockpitControlUpdate
    Task SendOutputsAsync(CockpitOutputSnapshot outputs, CancellationToken cancellationToken); //Send output snapshot to cockpit
}
