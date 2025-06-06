using System;
using System.Collections.Generic;
using System.Linq;

namespace UltraWorldAI.Research;

/// <summary>
/// Provides simple statistical analysis utilities for researchers.
/// </summary>
public static class DataAnalyzer
{
    public static string Analyze(IEnumerable<double> data)
    {
        var list = data.ToList();
        if (list.Count == 0) return "Sem dados";
        var avg = list.Average();
        var max = list.Max();
        var min = list.Min();
        return $"avg:{avg:F2}; max:{max:F2}; min:{min:F2}";
    }
}
