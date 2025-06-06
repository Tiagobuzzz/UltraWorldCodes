using UltraWorldAI.Game;

namespace UltraWorldAI.Game;

/// <summary>
/// Simple sandbox runner for quick experiments.
/// </summary>
public static class SandboxMode
{
    public static void Run()
    {
        var loop = new GameLoop(10, 10, display: true);
        var p = new Person("Explorador");
        loop.AddPerson(p, 5, 5);
        loop.Run(5);
    }
}
