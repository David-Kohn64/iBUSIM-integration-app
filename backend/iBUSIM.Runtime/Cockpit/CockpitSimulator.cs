namespace iBUSIM.Runtime.Cockpit;
using System.Runtime.CompilerServices; // Added this for the EnumeratorCancellation attribute

/*
    CockpitSimulator is a class that simulates the behavior of a cockpit device based on a given simulation scenario. 
    It implements the ICockpitDevice interface, providing methods to connect to the simulator, read control updates, and send output snapshots. 
    The class handles cancellation requests and logs relevant information to the console for debugging purposes.
*/

public sealed class CockpitSimulator(SimulationScenario scenario) : ICockpitDevice
{
    public CockpitOutputSnapshot? CurrentOutputs { get; private set; }

    /* 
        Given a scenario from SimulationScenario, it connects to the simulator and returns the initial snapshot of the cockpit controls.
        If there is a cancellation request, it throws an OperationCanceledException.
    */
    public Task<CockpitControlSnapshot> ConnectAsync(CancellationToken cancellationToken)
    {
        try
        {
            cancellationToken.ThrowIfCancellationRequested(); 

            // Retrieve the initial snapshot from the scenario
            // THIS IS PLACEHOLDER, NEED TO KNOW THE SCENARIO IMPLEMENTATION TO GET THE SNAPSHOT
            CockpitControlSnapshot snapshot = scenario.InitialSnapshot;

            // Successfully connected, return the snapshot
            Console.WriteLine("CockpitSimulator.cs connected successfully.");
            return Task.FromResult(snapshot);
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("CockpitSimulator.cs operation was canceled during ConnectAsync.");
            throw;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred in CockpitSimulator.cs during ConnectAsync: {ex.Message}");
            throw;
        }
    }

    /*
        Returns a stream of individual control updates from a configured scenario.
        If there is a cancellation request, it throws an OperationCanceledException.
    */
    // NOTE: added async keyword to the method signature to allow for asynchronous streaming of updates
    // NOTE: added [EnumeratorCancellation] attribute to the cancellationToken parameter to allow for proper cancellation of the async enumerable
    // NOTE: the delays may not be necessary in the simulator, but they are included here to simulate the timing of updates in a real cockpit scenario.
    public async IAsyncEnumerable<CockpitControlUpdate> ReadUpdatesAsync([EnumeratorCancellation] CancellationToken cancellationToken)
    {
        foreach (ScriptedControlUpdate scriptedUpdate in scenario.Updates)
        {
            try
            {
                cancellationToken.ThrowIfCancellationRequested();

                // Wait for the specified delay before sending the update
                await Task.Delay(scriptedUpdate.Delay, cancellationToken);
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("CockpitSimulator.cs operation was canceled during ReadUpdatesAsync.");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred in CockpitSimulator.cs during ReadUpdatesAsync: {ex.Message}");
                throw;
            }

            // Log in console and send the update to the runtime
            Console.WriteLine($"Cockpit Simulator sent update: {scriptedUpdate.Update}");
            yield return scriptedUpdate.Update;
        }
        Console.WriteLine("CockpitSimulator.cs finished sending updates.");
    }

    /*
        Given a snapshot of the cockpit outputs, it sends the outputs to the simulator and stores it.
        If there is a cancellation request, it throws an OperationCanceledException.
    */
    public Task SendOutputsAsync(CockpitOutputSnapshot outputs, CancellationToken cancellationToken)
    {
        try
        {
            cancellationToken.ThrowIfCancellationRequested();

            // Store the outputs in the CurrentOutputs property
            CurrentOutputs = outputs;

            Console.WriteLine($"CockpitSimulator.cs received outputs: {outputs}");
            return Task.CompletedTask;
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("CockpitSimulator.cs operation was canceled during SendOutputsAsync.");
            throw;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred in CockpitSimulator.cs during SendOutputsAsync: {ex.Message}");
            throw;
        }
    }
}
