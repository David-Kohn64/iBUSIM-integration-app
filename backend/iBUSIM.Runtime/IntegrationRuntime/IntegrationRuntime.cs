using iBUSIM.Runtime.Cockpit;
using Microsoft.Extensions.Logging;

namespace iBUSIM.Runtime;
public sealed class IntegrationRuntime
{
    private readonly ILogger<IntegrationRuntime> _logger;
    public CockpitControlSnapshot? CockpitState { get; private set; } //Current maintained state

    public CockpitOutputSnapshot ApplySnapshot(CockpitControlSnapshot snapshot)
    {
        //Check for a null input
        ArgumentNullException.ThrowIfNull(snapshot);

        //replace the stored cockpit state with our new complete snapshot
        CockpitState = snapshot;

        //Logs the operation
        _logger.LogInformation("Applied cockpit snapshot: Button={Button}, Analog={Analog}", snapshot.ButtonPressed, snapshot.AnalogValue);
        
        //Return a new output snapshot based on the current state (CURRENTLY FAKE)
        return new CockpitOutputSnapshot(
            IndicatorLightOn: snapshot.ButtonPressed,
            TelemetryValue: snapshot.AnalogValue);
    }

    public CockpitOutputSnapshot ApplyUpdate(CockpitControlUpdate update)
    {
        throw new NotImplementedException(); 
    }

    
}

