using iBUSIM.Runtime.Cockpit;
using Microsoft.Extensions.Logging;

namespace iBUSIM.Runtime;

public sealed class IntegrationRuntime
{
    private readonly ILogger<IntegrationRuntime> _logger;

    public IntegrationRuntime(ILogger<IntegrationRuntime> logger)
    {
        _logger = logger;
    }

    public CockpitControlSnapshot? CockpitState
        { get; private set; }

    public CockpitOutputSnapshot ApplySnapshot(
        CockpitControlSnapshot snapshot)
    {
        try
        {
            // Reject null snapshots.
            ArgumentNullException.ThrowIfNull(snapshot);

            // Reject invalid numeric readings.
            if (!double.IsFinite(snapshot.AnalogValue))
            {
                throw new ArgumentOutOfRangeException(
                    nameof(snapshot),
                    "AnalogValue must be a finite number."
                );
            }

            // Replace the entire current cockpit state.
            CockpitState = snapshot;

            // Log the applied snapshot for debugging purposes.
            _logger.LogInformation(
                "Snapshot applied: Button={Button}, Analog={Analog}",
                snapshot.ButtonPressed,
                snapshot.AnalogValue
            );

            // Return temporary simulated hardware outputs.
            return CreateFakeOutputs(snapshot);
        }
        catch (Exception ex)
        {
            _logger.LogError(
                ex, "Failed to apply cockpit snapshot"
            );

            throw;
        }
    }

    public CockpitOutputSnapshot ApplyUpdate(
        CockpitControlUpdate update)
    {
        try
        {
            // Reject null updates.
            ArgumentNullException.ThrowIfNull(update);

            // An initial snapshot must exist first.
            CockpitControlSnapshot currentState = CockpitState
                ?? throw new InvalidOperationException(
                    "Cannot apply update before initial snapshot."
                );

            // Create a new snapshot with only the
            // relevant control changed.
            CockpitControlSnapshot updatedState = update switch
            {
                ButtonControlUpdate button =>
                    currentState with
                    {
                        ButtonPressed = button.IsPressed
                    },

                AnalogControlUpdate analog
                    when double.IsFinite(analog.Value) =>
                    currentState with
                    {
                        AnalogValue = analog.Value
                    },

                AnalogControlUpdate =>
                    throw new ArgumentOutOfRangeException(
                        nameof(update),
                        "Analog value must be a finite number."
                    ),

                _ => throw new ArgumentException(
                    $"Unsupported update type: {update.GetType().Name}",
                    nameof(update)
                )
            };

            // Commit the successfully validated update.
            CockpitState = updatedState;

            //Log the applied update for debugging purposes.
            _logger.LogInformation(
                "Applied {UpdateType}: Button={Button}, Analog={Analog}",
                update.GetType().Name,
                updatedState.ButtonPressed,
                updatedState.AnalogValue
            );

            return CreateFakeOutputs(updatedState);
        }
        catch (Exception ex)
        {
            _logger.LogError(
                ex, "Failed to apply cockpit update"
            );

            throw;
        }
    }

    //Function used purely for testing purposes, to simulate the outputs of the cockpit based on the current state.
    private static CockpitOutputSnapshot CreateFakeOutputs(
        CockpitControlSnapshot state)
    {
        return new CockpitOutputSnapshot(
            IndicatorLightOn: state.ButtonPressed,
            TelemetryValue: state.AnalogValue
        );
    }
}


