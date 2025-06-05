using System;
using UltraWorldAI.World;

namespace UltraWorldAI.Civilization;

public static class CultureResponseSystem
{
    public static void EvaluateCulturalFit(SapientBeing being, Settlement local)
    {
        var raceCulture = RaceCultureSystem.GetForRace(being.Race)?.SocialStructure ?? "Tribal";
        var localCulture = local.CultureSummary;

        if (raceCulture == localCulture)
        {
            Console.WriteLine($"✅ {being.Name} se sente em casa em {local.Name}.");
            return;
        }

        var rand = new Random().NextDouble();

        if (rand < 0.3)
        {
            Console.WriteLine($"🛑 {being.Name} não aceita a cultura de {local.Name} e migra.");
            being.CurrentRegion = WorldSeedGenerator.GetNearbyRegion(local.Region);
        }
        else if (rand < 0.6)
        {
            Console.WriteLine($"🌀 {being.Name} entra em conflito cultural em {local.Name}.");
            SettlementHistoryTracker.Register(local.Name, "Conflito Interno", $"{being.Name} causou tensão filosófica.");
        }
        else
        {
            Console.WriteLine($"🔁 {being.Name} se converte à cultura de {local.Name}.");
            being.Race += "-Convertido";
        }
    }
}
