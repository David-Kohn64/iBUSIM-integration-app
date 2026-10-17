### CockpitDisplay.tsx - Rendered by App.tsx

- Creates and positioning the instrument windows as per DisplayCoordinator.cs

### InstrumentWindow.tsx - Rendered by App.tsx

- Determine current instrument and connect to DisplayHub and subscribe to its SignalR group
- Pass initial snapshot and live updates to that instrument’s renderer
- Report and update new layout state after moving/resizing a window

### AirspeedIndicator.tsx, AttitudeDirectorIndicator.tsx, Altimeter.tsx, VerticalVelocityIndicator.tsx, HorizontalSituationIndicator.tsx          -All rendered by InstrumentWindow.tsx

- Render the custom instrument based on state passed through props
- Contain custom animation behavior specific to that instrument
