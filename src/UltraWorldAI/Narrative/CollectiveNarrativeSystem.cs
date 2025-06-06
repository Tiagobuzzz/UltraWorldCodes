using System.Collections.Generic;
using System.Linq;

namespace UltraWorldAI.Narrative;

/// <summary>
/// Maintains narrative events shared across cultures and allows basic interaction.
/// </summary>
public static class CollectiveNarrativeSystem
{
    private static readonly List<(string Culture, string Summary)> _events = new();

    public static void ShareEvent(string cultureName, string summary)
    {
        _events.Add((cultureName, summary));
    }

    public static IEnumerable<string> GetEventsForCulture(string cultureName)
    {
        return _events.Where(e => e.Culture == cultureName).Select(e => e.Summary);
    }

    public static string DescribeInteractions()
    {
        return _events.Count == 0
            ? "Sem interações registradas."
            : string.Join("; ", _events.Select(e => $"{e.Culture}: {e.Summary}"));
    }
}
