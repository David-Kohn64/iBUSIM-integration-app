namespace iBUSIM.Runtime.Cockpit;

public sealed record CockpitControlSnapshot(
    bool ButtonPressed,
    double AnalogValue
    //will add more
); 

public abstract record CockpitControlUpdate;

public sealed record ButtonControlUpdate(bool IsPressed) : CockpitControlUpdate;

public sealed record AnalogControlUpdate(double Value) : CockpitControlUpdate;

public sealed record CockpitOutputSnapshot(
    bool IndicatorLightOn,
    double TelemetryValue
);




