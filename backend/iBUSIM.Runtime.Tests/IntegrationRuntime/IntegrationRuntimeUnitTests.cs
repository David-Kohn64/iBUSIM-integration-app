using iBUSIM.Runtime.Cockpit;
using Microsoft.Extensions.Logging.Abstractions;

namespace iBUSIM.Runtime.Tests;

public class IntegrationRuntimeUnitTests
{
    [Fact]
    public void ApplyAndStoresState_Test()
    {
        // Tests that applying a snapshot stores the state and returns matching outputs.
        var runtime = CreateRuntime();
        var snapshot = new CockpitControlSnapshot(
            ButtonPressed: true,
            AnalogValue: 0.75);

        CockpitOutputSnapshot outputs = runtime.ApplySnapshot(snapshot);

        Assert.Equal(snapshot, runtime.CockpitState);
        Assert.Equal(new CockpitOutputSnapshot(true, 0.75), outputs);
    }

    [Fact]
    public void ApplyUpdate_Test()
    {
        // Tests that applying an update preserves the button state and returns matching outputs.
        var runtime = CreateRuntime();
        var initialSnapshot = new CockpitControlSnapshot(
            ButtonPressed: true,
            AnalogValue: 0.25);
        runtime.ApplySnapshot(initialSnapshot);
        var expectedState = new CockpitControlSnapshot(
            ButtonPressed: true,
            AnalogValue: 0.8);

        CockpitOutputSnapshot outputs = runtime.ApplyUpdate(
            new AnalogControlUpdate(expectedState.AnalogValue));

        Assert.Equal(expectedState, runtime.CockpitState);
        Assert.Equal(new CockpitOutputSnapshot(true, 0.8), outputs);
    }

    private static global::iBUSIM.Runtime.IntegrationRuntime CreateRuntime() =>
        new(NullLogger<global::iBUSIM.Runtime.IntegrationRuntime>.Instance);
}