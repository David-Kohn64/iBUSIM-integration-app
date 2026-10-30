using iBUSIM.Runtime.Cockpit;

namespace iBUSIM.Runtime;
public sealed class IntegrationRuntime
{
    public CockpitControlSnapshot? CockpitState { get; private set; } //Current maintained state

    public CockpitOutputSnapshot ApplySnapshot(CockpitControlSnapshot snapshot)
    {
        throw new NotImplementedException(); //Remove
    }

    public CockpitOutputSnapshot ApplyUpdate(CockpitControlUpdate update)
    {
        throw new NotImplementedException(); 
    }

    
}

