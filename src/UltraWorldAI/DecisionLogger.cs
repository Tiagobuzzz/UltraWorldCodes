namespace UltraWorldAI;

public static class DecisionLogger
{
    public static void LogDecision(string actor, string decision)
    {
        Logger.Log($"[Decision] {actor}: {decision}", LogLevel.Debug);
    }
}
