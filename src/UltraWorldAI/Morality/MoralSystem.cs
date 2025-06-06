using System;
using System.Collections.Generic;

namespace UltraWorldAI.Morality;

/// <summary>
/// Tracks morality values that change over time.
/// </summary>
public class MoralSystem
{
    private readonly Dictionary<string, float> _values = new();

    public void UpdateValue(string key, float delta)
    {
        var current = _values.ContainsKey(key) ? _values[key] : 0f;
        _values[key] = Math.Clamp(current + delta, 0f, 1f);
    }

    public float GetValue(string key) => _values.TryGetValue(key, out var v) ? v : 0f;
}
