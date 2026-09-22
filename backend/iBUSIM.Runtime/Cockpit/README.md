### CockpitWorker.cs - Started by Program.cs, Called by Integration Runtime

- Select real hardware vs. cockpit simulator
- Connect to serial device by calling SerialCockpitDevice.cs
- Handle disconnection/retry
- Require hardware snapshot
- Pass incoming messages to Parser.cs and forward to the Integration Runtime.

### SerialCockpitDevice.cs - Called by CockpitWorker.cs, ProtocolEncoder.cs

- Discover and connect to serial USB device
- Read data from serial port 
- Send data to serial port
- Error handling

### Parser.cs - Called by CockpitWorker.cs

- Validate message protocol and handle errors
- Receive a hardware snapshot at connection
- Parse and translate message protocol into usable values

### ProtocolEncoder.cs - Called by CockpitWorker.cs

- Converts telemetry data, indicator lights, force feedback data into message protocol

### CockpitSimulator.cs - Called by CockpitWorker.cs

- Provide a snapshot of controls
- Provide control inputs
- Accept and present telemetry data
