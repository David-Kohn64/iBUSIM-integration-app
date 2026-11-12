using Microsoft.Extensions.Logging.Abstractions;
using iBUSIM.Runtime;
using iBUSIM.Runtime.Cockpit;

namespace iBUSIM.Runtime.Tests.Cockpit;

public class CockpitWorkerUnitTests
{
    [Fact]
    public async Task ExecuteAsync_WhenThereAreNoUpdates_Completes()
    {
        // Tests that the worker completes when there are no updates.
        var device = new CockpitSimulator(new SimulationScenario(
            new CockpitControlSnapshot(false, 0),
            []));
        // Creates a CockpitWorker instance with the simulator device and a null logger.
        using var worker = new CockpitWorker(
            new IntegrationRuntime(),
            device,
            NullLogger<CockpitWorker>.Instance);

        // Starts the worker and waits for it to complete.
        await worker.StartAsync(CancellationToken.None);
        await worker.ExecuteTask!.WaitAsync(TimeSpan.FromSeconds(1));
    }

    [Fact(Skip = "IntegrationRuntime.ApplyUpdate is not implemented yet.")]
    // Tests that the worker sends output to the device when an update arrives.
    // This test is currently skipped because IntegrationRuntime.ApplyUpdate is not implemented yet.
    public async Task ExecuteAsync_WhenUpdateArrives_SendsOutputToDevice()
    {
        var device = new CockpitSimulator(new SimulationScenario(
            new CockpitControlSnapshot(false, 0),
            [new ScriptedControlUpdate(TimeSpan.Zero, new ButtonControlUpdate(true))]));
        using var worker = new CockpitWorker(
            new IntegrationRuntime(),
            device,
            NullLogger<CockpitWorker>.Instance);

        await worker.StartAsync(CancellationToken.None);
        await worker.ExecuteTask!.WaitAsync(TimeSpan.FromSeconds(1));

        Assert.NotNull(device.CurrentOutputs);
    }
}
