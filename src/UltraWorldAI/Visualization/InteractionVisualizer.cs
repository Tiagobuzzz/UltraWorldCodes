using System.Collections.Generic;

namespace UltraWorldAI.Visualization;

public static class InteractionVisualizer
{
    public static List<string> Log { get; } = new();

    public static void RecordExchange(string from, string to, string text)
    {
        var entry = $"{from} -> {to}: {text}";
        Log.Add(entry);
    }
}
