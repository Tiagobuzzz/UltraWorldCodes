using System;
using System.Collections.Generic;

namespace UltraWorldAI.Politics;

public class PowerPlot
{
    public string Instigator { get; set; } = string.Empty;
    public string TargetKingdom { get; set; } = string.Empty;
    public string Method { get; set; } = string.Empty; // "Casamento", "Golpe", "Assassinato", "Suborno"
    public bool WasSuccessful { get; set; }
}

public static class PowerIntrigueSystem
{
    public static List<PowerPlot> Plots { get; } = new();

    public static void ExecutePlot(string instigator, string kingdom, string method)
    {
        var success = RandomSingleton.Shared.NextDouble() > 0.4;
        Plots.Add(new PowerPlot
        {
            Instigator = instigator,
            TargetKingdom = kingdom,
            Method = method,
            WasSuccessful = success
        });

        Console.WriteLine(success
            ? $"🎭 {instigator} executou com sucesso um {method} em {kingdom}."
            : $"❌ {instigator} falhou ao tentar um {method} em {kingdom}.");
    }

    public static void PrintPlots()
    {
        foreach (var p in Plots)
            Console.WriteLine($"\n🔪 {p.Instigator} tentou {p.Method} em {p.TargetKingdom} | Sucesso: {p.WasSuccessful}");
    }
}
