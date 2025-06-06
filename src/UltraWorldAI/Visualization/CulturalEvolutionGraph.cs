using System.Collections.Generic;

namespace UltraWorldAI.Visualization;

/// <summary>
/// Simple container for cultural evolution data points to be visualized as a graph.
/// </summary>
public class CulturalEvolutionGraph
{
    private readonly List<(int year, double value)> _points = new();

    public void AddPoint(int year, double value)
    {
        _points.Add((year, value));
    }

    public IReadOnlyList<(int year, double value)> GetPoints() => _points;
}
