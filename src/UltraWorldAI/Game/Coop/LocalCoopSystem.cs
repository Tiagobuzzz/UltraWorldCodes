namespace UltraWorldAI.Game.Coop;

/// <summary>
/// Basic state holder for local cooperative mode with split screen.
/// </summary>
public static class LocalCoopSystem
{
    public static bool IsEnabled { get; private set; }

    public static void Enable() => IsEnabled = true;
    public static void Disable() => IsEnabled = false;
}
