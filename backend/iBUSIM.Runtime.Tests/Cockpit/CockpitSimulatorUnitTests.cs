using iBUSIM.Runtime.Cockpit;

namespace iBUSIM.Runtime.Tests.Cockpit;

public class CockpitSimulatorUnitTests
{
    // Tests that all simulation scenarios in CockpitSimulator.cs work as intended.
    // To run, type the following command:
    // dotnet test backend/iBUSIM.Runtime.Tests

    [Fact]
    public async Task ConnectAsync_Test()
    {
        // Tests that ConnectAsync returns the scenario's initial snapshot.
        var expected = new CockpitControlSnapshot(ButtonPressed: true, AnalogValue: 0.75);
        var simulator = new CockpitSimulator(new SimulationScenario(expected, []));

        // Connect to the simulator and retrieve the initial snapshot.
        CockpitControlSnapshot actual = await simulator.ConnectAsync(CancellationToken.None);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public async Task ReadUpdatesAsync_Test()
    {
        // Tests that ReadUpdatesAsync updates the cockpit state properly
        CockpitControlUpdate[] expected =
        [
            new ButtonControlUpdate(true),
            new AnalogControlUpdate(0.25),
            new ButtonControlUpdate(false)
        ];
        // Creates a simulation scenario with the expected updates.
        var scenario = new SimulationScenario(
            new CockpitControlSnapshot(ButtonPressed: false, AnalogValue: 0),
            expected.Select(update => new ScriptedControlUpdate(TimeSpan.Zero, update)).ToArray());
        var simulator = new CockpitSimulator(scenario);

        // Read updates from the simulator.
        List<CockpitControlUpdate> actual = [];
        await foreach (CockpitControlUpdate update in simulator.ReadUpdatesAsync(CancellationToken.None))
        {
            actual.Add(update);
        }

        Assert.Equal(expected, actual);
    }

    [Fact]
    public async Task SendOutputsAsync_Test()
    {
        // Tests that SendOutputsAsync takes in the latest snapshot, testing that it works as expected.
        var simulator = new CockpitSimulator(new SimulationScenario(
            new CockpitControlSnapshot(ButtonPressed: false, AnalogValue: 0),
            []));
        var outputs = new CockpitOutputSnapshot(IndicatorLightOn: true, TelemetryValue: 42.5);

        await simulator.SendOutputsAsync(outputs, CancellationToken.None);

        Assert.Equal(outputs, simulator.CurrentOutputs);
    }
}
