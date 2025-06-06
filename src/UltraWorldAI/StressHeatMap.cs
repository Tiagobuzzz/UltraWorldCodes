using System.Collections.Generic;

namespace UltraWorldAI;

/// <summary>
/// Simple heat map aggregating stress levels across a grid.
/// </summary>
public class StressHeatMap
{
    private readonly Dictionary<(int x, int y), float> _map = new();

    public void Record(int x, int y, float stress)
    {
        var key = (x, y);
        _map[key] = _map.GetValueOrDefault(key) + stress;
    }

    public float GetStress(int x, int y) => _map.GetValueOrDefault((x, y));
}
