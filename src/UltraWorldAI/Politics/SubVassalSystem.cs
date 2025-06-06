using System;
using System.Collections.Generic;

namespace UltraWorldAI.Politics;

public class SubVassal
{
    public string HouseMinor { get; set; } = string.Empty;
    public string HouseMajor { get; set; } = string.Empty;
    public string Region { get; set; } = string.Empty;
    public bool IsRebellious { get; set; }
}

public static class SubVassalSystem
{
    public static List<SubVassal> Network { get; } = new();

    public static void RegisterSubVassal(string minor, string major, string region)
    {
        Network.Add(new SubVassal
        {
            HouseMinor = minor,
            HouseMajor = major,
            Region = region,
            IsRebellious = false
        });

        Console.WriteLine($"\U0001F3DA️ Casa menor {minor} jurou serviço à casa maior {major} em {region}.");
    }

    public static void DeclareRebellion(string minor)
    {
        var v = Network.Find(x => x.HouseMinor == minor);
        if (v != null)
        {
            v.IsRebellious = true;
            Console.WriteLine($"\u2694️ Casa menor {minor} se rebelou contra {v.HouseMajor}!");
        }
    }

    public static void PrintNetwork()
    {
        foreach (var v in Network)
            Console.WriteLine($"\n\U0001F3F0 {v.HouseMinor} ➜ {v.HouseMajor} | Região: {v.Region} | Rebelde? {v.IsRebellious}");
    }
}
