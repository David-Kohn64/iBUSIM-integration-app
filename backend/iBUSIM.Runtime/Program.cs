using iBUSIM.Runtime;
using iBUSIM.Runtime.Cockpit;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


builder.Services.AddSingleton<IntegrationRuntime>();
builder.Services.AddSingleton(SimulationScenarios.Scenario1);

//Provide CockpitSimulator as the ICockpitDevice (replace with SerialCockpitDevice later)
builder.Services.AddSingleton<ICockpitDevice, CockpitSimulator>(); 
builder.Services.AddHostedService<CockpitWorker>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapOperatorEndpoints();

app.Run();
