namespace UltraWorldAI;

public static class DecisionLogger
{
    public static void LogDecision(string actor, string decision,
        [System.Runtime.CompilerServices.CallerMemberName] string member = "",
        [System.Runtime.CompilerServices.CallerFilePath] string file = "",
        [System.Runtime.CompilerServices.CallerLineNumber] int line = 0)
    {
        var detail = $"[Decision] {actor}: {decision} (at {System.IO.Path.GetFileName(file)}:{line} in {member})";
        Logger.Log(detail, LogLevel.Debug);
    }
}
