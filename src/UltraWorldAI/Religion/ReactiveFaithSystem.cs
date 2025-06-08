using System;
using System.Collections.Generic;

namespace UltraWorldAI.Religion;

public static class ReactiveFaithSystem
{
    private static readonly Dictionary<string, int> _miracleCounts = new();
    private static readonly Dictionary<string, float> _fanaticism = new();

    public static void RecordMiracle(string culture)
    {
        if (!_miracleCounts.ContainsKey(culture))
            _miracleCounts[culture] = 0;
        _miracleCounts[culture]++;
        Adjust(culture);
    }

    private static void Adjust(string culture)
    {
        var count = _miracleCounts[culture];
        var level = Math.Clamp(0.5f + count * 0.1f, 0f, 1f);
        _fanaticism[culture] = level;
    }

    public static float GetFanaticism(string culture)
    {
        return _fanaticism.TryGetValue(culture, out var level) ? level : 0.5f;
    }
}

