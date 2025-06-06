using System.Linq;

namespace UltraWorldAI;

public static class BeliefConflictVisualizer
{
    public static string Visualize(BeliefArchitecture arch)
    {
        var contradictions = arch.DetectContradictions();
        if (contradictions.Count == 0) return "Nenhum conflito de crenças.";
        return string.Join("\n", contradictions.Select(c => $"{c.Item1.Statement} <-> {c.Item2.Statement}"));
    }
}
