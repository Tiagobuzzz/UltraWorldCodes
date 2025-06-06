using System.Collections.Generic;

namespace UltraWorldAI.World.Ecology;

public static class DynamicWeatherEconomy
{
    private static readonly Dictionary<string, double> _yields = new();

    public static void RegisterRegion(string region, double baseYield)
    {
        _yields[region] = baseYield;
    }

    public static void ApplyWeatherEvent(string region, ClimateEvent evt)
    {
        if (!_yields.ContainsKey(region)) return;
        double modifier = evt.Type switch
        {
            "Seca" => -0.3,
            "Furacao" => -0.2,
            "Tempestade" => -0.1,
            "Chuva" => 0.1,
            "Nevasca" => -0.15,
            _ => 0
        };
        _yields[region] += _yields[region] * modifier;
        MapFaithEconomyIntegration.UpdateNodeWealth(region, _yields[region] * modifier);
    }

    public static double GetYield(string region) => _yields.GetValueOrDefault(region);
}
