using Xunit;
using iBUSIM.Runtime.Cockpit;

namespace iBUSIM.Runtime.Tests.Cockpit;

public class SimulationScenariosTests
{
    // Tests that all simulation scenarios in SimulationScenarios.cs are initialized.
    // To run, type the following command:
    // dotnet test backend/iBUSIM.Runtime.Tests

    [Fact]
    public void Scenario1_IsNotNull()
    {
        // Check that Scenario1 is initialized correctly.
        Assert.NotNull(SimulationScenarios.Scenario1);

        var scenario1 = SimulationScenarios.Scenario1;
        // Check that the initial snapshot and updates are initialized correctly.
        Assert.False(scenario1.InitialSnapshot.ButtonPressed);
        Assert.Equal(0.0, scenario1.InitialSnapshot.AnalogValue);
        Assert.Equal(4, scenario1.Updates.Count);
    }
    [Fact]
    public void Scenario2_IsNotNull()
    {
        // Check that Scenario2 is initialized correctly.
        Assert.NotNull(SimulationScenarios.Scenario2);

        // Check that the initial snapshot and updates are initialized correctly.
        var scenario2 = SimulationScenarios.Scenario2;
        Assert.True(scenario2.InitialSnapshot.ButtonPressed);
        Assert.Equal(0.0, scenario2.InitialSnapshot.AnalogValue);
        Assert.Equal(4, scenario2.Updates.Count);
    }
    [Fact]
    public void Scenario3_IsNotNull()
    {
        // Check that Scenario3 is initialized correctly.
        Assert.NotNull(SimulationScenarios.Scenario3);

        // Check that the initial snapshot and updates are initialized correctly.
        var scenario3 = SimulationScenarios.Scenario3;
        Assert.False(scenario3.InitialSnapshot.ButtonPressed);
        Assert.Equal(0.5, scenario3.InitialSnapshot.AnalogValue);
        Assert.Equal(5, scenario3.Updates.Count);
    }
}