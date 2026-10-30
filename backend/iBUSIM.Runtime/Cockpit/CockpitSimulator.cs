namespace iBUSIM.Runtime.Cockpit;

public sealed class CockpitSimulator(SimulationScenario scenario) : ICockpitDevice
{
    public CockpitOutputSnapshot? CurrentOutputs { get; private set; }
    public Task<CockpitControlSnapshot> ConnectAsync(CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested(); 

        throw new NotImplementedException(); //Remove
    }

    public IAsyncEnumerable<CockpitControlUpdate> ReadUpdatesAsync(CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        throw new NotImplementedException();
    }

    public Task SendOutputsAsync(CockpitOutputSnapshot outputs, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        throw new NotImplementedException();
    }

}
