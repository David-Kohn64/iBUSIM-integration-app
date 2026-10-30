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

            await Task.Delay(Timeout.InfiniteTimeSpan, stoppingToken);
        }
        catch (OperationCanceledException) when (stoppingToken.IsCancellationRequested)
        {
            // Normal application shutdown.
        }

        logger.LogInformation("Cockpit worker stopped");
    }
}
