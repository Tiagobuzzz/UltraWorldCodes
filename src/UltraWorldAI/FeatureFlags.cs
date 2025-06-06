namespace UltraWorldAI;

/// <summary>
/// Centralizes toggles for experimental features.
/// </summary>
public static class FeatureFlags
{
    /// <summary>Enable integration of prophecies with real world events.</summary>
    public static bool ProphecyRealEventsEnabled { get; set; }

    /// <summary>Enable experimental AI behaviors.</summary>
    public static bool ExperimentalAIMode { get; set; }
}
