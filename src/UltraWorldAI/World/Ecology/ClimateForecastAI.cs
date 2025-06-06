using System.Collections.Generic;
using System.Linq;

namespace UltraWorldAI.World.Ecology;

/// <summary>
/// Provides naive climate forecasts based on historical event frequencies.
/// </summary>
public static class ClimateForecastAI
{
    private static readonly Dictionary<string, Dictionary<string, int>> _history = new();

    public static void RecordEvent(ClimateEvent evt)
    {
        if (!_history.ContainsKey(evt.Region))
            _history[evt.Region] = new();
        var dict = _history[evt.Region];
        if (!dict.ContainsKey(evt.Type))
            dict[evt.Type] = 0;
        dict[evt.Type]++;
    }

    public static Dictionary<string, double> PredictProbabilities(string region)
    {
        if (!_history.ContainsKey(region)) return new();
        int total = _history[region].Values.Sum();
        return _history[region].ToDictionary(kvp => kvp.Key, kvp => (double)kvp.Value / total);
    }
}

