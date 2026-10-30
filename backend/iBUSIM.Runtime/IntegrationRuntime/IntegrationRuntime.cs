using iBUSIM.Runtime.Cockpit;

namespace iBUSIM.Runtime;
public sealed class IntegrationRuntime
{
    public CockpitControlSnapshot? CockpitState { get; private set; } //Current maintained state

    public CockpitOutputSnapshot ApplySnapshot(CockpitControlSnapshot snapshot)
    {
          
    }

    public CockpitOutputSnapshot ApplyUpdate(CockpitControlUpdate update)
    {
          
    }

    
}

