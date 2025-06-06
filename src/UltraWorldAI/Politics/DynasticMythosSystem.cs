using System;
using System.Collections.Generic;

namespace UltraWorldAI.Politics;

public class DynasticMyth
{
    public string HouseName { get; set; } = string.Empty;
    public string OriginStory { get; set; } = string.Empty; // "Descendente dos Deuses", "Sangue Amaldiçoado", etc.
    public bool IsRevered { get; set; }
    public bool IsFeared { get; set; }
}

public static class DynasticMythosSystem
{
    public static List<DynasticMyth> Legends { get; } = new();

    public static void DeclareMyth(string house, string story, bool revered, bool feared)
    {
        Legends.Add(new DynasticMyth
        {
            HouseName = house,
            OriginStory = story,
            IsRevered = revered,
            IsFeared = feared
        });

        Console.WriteLine($"💠 Lenda criada: Casa {house} — {story} | Reverência: {revered} | Temor: {feared}");
    }

    public static void PrintMyths()
    {
        foreach (var d in Legends)
            Console.WriteLine($"\n🏰 Casa {d.HouseName} | Lenda: {d.OriginStory} | Reverência: {d.IsRevered} | Temida? {d.IsFeared}");
    }
}
