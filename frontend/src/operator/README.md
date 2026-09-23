### OperatorInterface.tsx - Rendered by App.tsx

- Header and overall layout
- Status and Cockpit panels (collapsable/minimizable)
- Stop iBUSIM button

### StatusPanel.tsx - Rendered by OperatorInterface.tsx

- Request preflight check on start and by request
- Display success, errors, and other messages of preflight check
- Display messages of live changes of button presses, analog values, indicator lights etc.

### CockpitPanel.tsx - Rendered by OperatorInterface.tsx

- Display every control in cockpit and its state and connection status
- Controls light up when value changes
- Button calibration/reassignment
- Cockpit testing like indicators and force feedback

### runtimeApi.ts - Called by OperatorInterface.tsx, StatusPanel.tsx, CockpitPanel.tsx

- All functions needed to communicate with backend

