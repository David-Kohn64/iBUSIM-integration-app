using Xunit;
using iBUSIM.Runtime.Cockpit;

namespace iBUSIM.Runtime.Tests.Cockpit;

public class SimulationScenariosTests
{
    // Tests that all simulation scenarios in SimulationScenarios.cs are initialized.
    [Fact]
    public void Scenario1_IsNotNull()
    {
        Assert.NotNull(SimulationScenarios.Scenario1);
    }
    [Fact]
    public void Scenario2_IsNotNull()
    {
        Assert.NotNull(SimulationScenarios.Scenario2);
    }
    [Fact]
    public void Scenario3_IsNotNull()
    {
        Assert.NotNull(SimulationScenarios.Scenario3);
    }
}