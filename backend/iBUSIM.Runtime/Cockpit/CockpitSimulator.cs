namespace iBUSIM.Runtime.Cockpit;

public sealed class CockpitSimulator(SimulationScenario scenario) : ICockpitDevice
{
    public CockpitOutputSnapshot? CurrentOutputs { get; private set; }
    public Task<CockpitControlSnapshot> ConnectAsync(CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested(); 

        return Task.FromResult();
    }

    public IAsyncEnumerable<CockpitControlUpdate> ReadUpdatesAsync(CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        yield return ;
    }

    public Task SendOutputsAsync(CockpitOutputSnapshot outputs, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        return Task.CompletedTask;
    }

}
