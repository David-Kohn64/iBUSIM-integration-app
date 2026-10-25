public static class OperatorEndpoints
{
    public static void MapOperatorEndpoints(this WebApplication app)
    {
        app.MapPost("/api/stop", (HttpContext context, IHostApplicationLifetime lifetime, ILogger<Program> logger) =>
        {
            logger.LogInformation("Stop button clicked");

            context.Response.OnCompleted(() =>
            {
                lifetime.StopApplication();
                return Task.CompletedTask;
            });

            return Results.NoContent();
        });
    }









}
