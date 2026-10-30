namespace iBUSIM.Runtime.Cockpit;

public sealed record SimulationScenario(
    CockpitControlSnapshot InitialSnapshot,
    IReadOnlyList<ScriptedControlUpdate> Updates
);

public sealed record ScriptedControlUpdate(
    TimeSpan Delay,
    CockpitControlUpdate Update
);