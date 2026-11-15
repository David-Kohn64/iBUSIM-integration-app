using iBUSIM.Runtime.Cockpit;
using Microsoft.Extensions.Logging.Abstractions;

namespace iBUSIM.Runtime.Tests.Cockpit;

public class CockpitWorkerUnitTests
{
    // Tests that all scenarios in CockpitWorker.cs work as intended. 
    // To run, type the following command:
    // dotnet test backend/iBUSIM.Runtime.Tests
    [Fact]
    public async Task ExecuteAsync_NoUpdates_Test()
    {
        // Tests that the worker completes when no updates are available.
        var device = new CockpitSimulator(new SimulationScenario(
            new CockpitControlSnapshot(false, 0),
            []));
        // Create the integration runtime and cockpit worker.
        var runtime = new IntegrationRuntime(NullLogger<IntegrationRuntime>.Instance);
        using var worker = new CockpitWorker(
            runtime,
            device,
            NullLogger<CockpitWorker>.Instance);

        // Start the worker and wait for it to complete.
        await worker.StartAsync(CancellationToken.None);
        await worker.ExecuteTask!.WaitAsync(TimeSpan.FromSeconds(1));
    }

    [Fact]
    public async Task ExecuteAsync_UpdateArrives_Test()
    {
        // Tests that the worker sends the output to the device when an update arrives.
        var runtime = new IntegrationRuntime(NullLogger<IntegrationRuntime>.Instance);
        // Apply the initial cockpit control snapshot to the runtime.
        runtime.ApplySnapshot(new CockpitControlSnapshot(true, 0.75));
        // Create the cockpit simulator with the scripted control update.
        var device = new CockpitSimulator(new SimulationScenario(
            new CockpitControlSnapshot(true, 0.75),
            [new ScriptedControlUpdate(TimeSpan.Zero, new ButtonControlUpdate(false))]));
        // Create the cockpit worker.
        using var worker = new CockpitWorker(
            runtime,
            device,
            NullLogger<CockpitWorker>.Instance);

        // Start the worker and wait for it to complete.
        await worker.StartAsync(CancellationToken.None);
        await worker.ExecuteTask!.WaitAsync(TimeSpan.FromSeconds(1));

        // Verify that the output was sent to the device and the runtime state was updated.
        Assert.Equal(new CockpitOutputSnapshot(false, 0.75), device.CurrentOutputs);
        Assert.Equal(new CockpitControlSnapshot(false, 0.75), runtime.CockpitState);
    }
}
