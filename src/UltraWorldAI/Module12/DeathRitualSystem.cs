using System;
using System.Collections.Generic;

namespace UltraWorldAI.Module12;

public class DeathRecord
{
    public string Name { get; set; } = string.Empty;
    public string Cause { get; set; } = string.Empty;
    public string Culture { get; set; } = string.Empty;
    public string Ritual { get; set; } = string.Empty;
    public bool SpiritAppeased { get; set; }
}

public static class DeathRitualSystem
{
    public static List<DeathRecord> Records { get; } = new();

    public static void RecordDeath(string name, string cause, string culture, string ritual, bool appeased)
    {
        Records.Add(new DeathRecord
        {
            Name = name,
            Cause = cause,
            Culture = culture,
            Ritual = ritual,
            SpiritAppeased = appeased
        });

        Console.WriteLine($"\u26B0\uFE0F Morte: {name} | Causa: {cause} | Ritual: {ritual} | Espírito apaziguado? {appeased}");
    }

    public static void PrintDeaths()
    {
        foreach (var d in Records)
            Console.WriteLine($"\n\uD83D\uDD6F️ {d.Name} | Cultura: {d.Culture} | Causa: {d.Cause} | Ritual: {d.Ritual} | Espírito apaziguado: {d.SpiritAppeased}");
    }
}
