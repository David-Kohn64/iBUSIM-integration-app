### DisplayCoordinator.cs - Called by Integration Runtime

- Validate and apply display layout 
- Publish live state updates for flight instruments using SignalR to DisplayHub.cs ( IHubContext<DisplayHub>)

### DisplayHub.cs - Exposed by Program.cs (i.e. /hubs/display)

- Accept frontend SignalR connections
- Allow each instrument to subscribe to its own channel/group
- Route updates published by DisplayCoordinator.cs to subscribed instruments

### DcsViewportConfigurator.cs - Called by DisplayCoordinator.cs

- Generate MonitorSetup Lua for the Left DDI, Right DDI, and AMPCD.
- Install or replace current script into the DCS MonitorSetup directory

### DisplayEndpoints.cs - Called by runtimeApi.ts

- All API endpoints used by Display frontend 

### DisplayContracts.cs 

- Defines C# request and response types used by DisplayEndpoints.cs
- Define layout and SignalR message types used by DisplayHub.cs
