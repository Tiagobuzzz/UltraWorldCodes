using System.Collections.Generic;
using System.Linq;

namespace UltraWorldAI.Energy;

public static class EnergyGrid
{
    private static readonly Dictionary<string, double> _sources = new();
    private static readonly Dictionary<string, double> _consumers = new();

    public static void AddSource(string name, double output)
    {
        _sources[name] = output;
    }

    public static void AddConsumer(string name, double demand)
    {
        _consumers[name] = demand;
    }

    public static double Balance()
    {
        double supply = _sources.Values.Sum();
        double demand = _consumers.Values.Sum();
        return supply - demand;
    }

    public static string GetStatus()
    {
        return $"\u26A1 Fornecimento: {_sources.Values.Sum()} / Demanda: {_consumers.Values.Sum()}";
    }
}
