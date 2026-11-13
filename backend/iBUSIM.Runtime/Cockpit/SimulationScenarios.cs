namespace iBUSIM.Runtime.Cockpit;

//Scenario1 only updates the button
//Scenario 2 and 3 update both analog and button at varying times


public static class SimulationScenarios
{
    public static SimulationScenario Scenario1 =>
        new SimulationScenario(
            //Create the initial snapshot scenario
            InitialSnapshot: new CockpitControlSnapshot (
                ButtonPressed: false,
                AnalogValue: 0.0
            ),
            //Create a list of updates
            Updates: new[]
            {
                new ScriptedControlUpdate(
                    TimeSpan.FromSeconds(.2), 
                    new ButtonControlUpdate(true)
                    ),
                new ScriptedControlUpdate(
                    TimeSpan.FromSeconds(1),
                    new ButtonControlUpdate(false)
                    ),
                new ScriptedControlUpdate(
                    TimeSpan.FromSeconds(.5), 
                    new ButtonControlUpdate(true)
                    ),
                new ScriptedControlUpdate(
                    TimeSpan.FromSeconds(.02), 
                    new ButtonControlUpdate(false)
                    )
            }
        );

    public static SimulationScenario Scenario2 =>
        new SimulationScenario(
            //Create the initial snapshot scenario
            InitialSnapshot: new CockpitControlSnapshot (
                ButtonPressed: true,
                AnalogValue: 0.0
            ),
            //Create a list of updates
            Updates: new[]
            {
                new ScriptedControlUpdate(
                    TimeSpan.FromSeconds(.2), 
                    new AnalogControlUpdate(0.5)
                    ),
                new ScriptedControlUpdate(
                    TimeSpan.FromSeconds(.3),
                    new ButtonControlUpdate(false)
                    ),
                new ScriptedControlUpdate(
                    TimeSpan.FromSeconds(2),
                    new AnalogControlUpdate(0.2)
                    ),
                new ScriptedControlUpdate(
                    TimeSpan.FromSeconds(5),
                    new ButtonControlUpdate(true)
                    )
            }
        );

    public static SimulationScenario Scenario3 =>
        new SimulationScenario(
            InitialSnapshot: new CockpitControlSnapshot (
                ButtonPressed: false,
                AnalogValue: 0.5
            ),
            //Creates a list of updates
            Updates: new[]
            {
                new ScriptedControlUpdate(
                    TimeSpan.FromSeconds(1), 
                    new ButtonControlUpdate(true)
                    ),
                new ScriptedControlUpdate(
                    TimeSpan.FromSeconds(1.5),
                    new ButtonControlUpdate(false)
                    ),
                new ScriptedControlUpdate(
                    TimeSpan.FromSeconds(3),
                    new AnalogControlUpdate(0.1)
                    ),
                new ScriptedControlUpdate(
                    TimeSpan.FromSeconds(4),
                    new ButtonControlUpdate(true)
                ),
                new ScriptedControlUpdate(
                    TimeSpan.FromSeconds(.1),
                    new ButtonControlUpdate(false)
                )
            }
        );
}