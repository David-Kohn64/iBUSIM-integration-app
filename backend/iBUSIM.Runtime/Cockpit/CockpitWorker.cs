namespace iBUSIM.Runtime.Cockpit;

public sealed class CockpitWorker(
    IntegrationRuntime integrationRuntime,
    ICockpitDevice cockpitDevice, 
    ILogger<CockpitWorker> logger
    ) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        logger.LogInformation("Cockpit worker started");

        try
        {
            //sends initial snapshot to Integration Runtime and passes outputs to Cockpit Device
            CockpitControlSnapshot initialSnapshot = await cockpitDevice.ConnectAsync(stoppingToken);
            CockpitOutputSnapshot initialOutputs = integrationRuntime.ApplySnapshot(initialSnapshot); //Outputs will not be sent this way in future
            await cockpitDevice.SendOutputsAsync(initialOutputs, stoppingToken); 

            await foreach (
                CockpitControlUpdate update in cockpitDevice.ReadUpdatesAsync(stoppingToken)
            )
            {
                logger.LogInformation("Cockpit control update received");

                CockpitOutputSnapshot cockpitOutputSnapshot = integrationRuntime.ApplyUpdate(update);

                logger.LogInformation("Cockpit output updated. IndicatorLightOn: {LightStatus}, TelemetryValue: {TelemetryValue}",
                cockpitOutputSnapshot.IndicatorLightOn, cockpitOutputSnapshot.TelemetryValue);

                await cockpitDevice.SendOutputsAsync(cockpitOutputSnapshot, stoppingToken);

                logger.LogInformation("Cockpit output successfully sent to device");
            }

        }
        catch (OperationCanceledException) when (stoppingToken.IsCancellationRequested)
        {
            // Normal application shutdown.
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Cockpit worker failed");
        }

        logger.LogInformation("Cockpit worker stopped");
    }
}
