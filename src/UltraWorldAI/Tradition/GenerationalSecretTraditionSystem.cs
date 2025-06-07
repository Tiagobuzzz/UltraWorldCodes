using System;
using System.Collections.Generic;

namespace UltraWorldAI.Tradition;

public class GenerationalSecret
{
    public string TraditionName = string.Empty;
    public string Secret = string.Empty;
    public int YearsKept;
    public string DestinedOne = string.Empty;
}

public static class GenerationalSecretTraditionSystem
{
    public static List<GenerationalSecret> Secrets { get; } = new();

    public static void RecordSecret(string tradition, string secret, string destinedOne)
    {
        Secrets.Add(new GenerationalSecret
        {
            TraditionName = tradition,
            Secret = secret,
            DestinedOne = destinedOne,
            YearsKept = 0
        });
        Console.WriteLine($"\u2728 Segredo registrado em '{tradition}' para {destinedOne}");
    }

    public static void AdvanceYears(int years)
    {
        foreach (var s in Secrets)
            s.YearsKept += years;
    }

    public static string? Reveal(string tradition, string person)
    {
        var secret = Secrets.Find(s => s.TraditionName == tradition && s.DestinedOne == person);
        if (secret == null) return null;
        Console.WriteLine($"\uD83C\uDF19 Segredo revelado a {person} ap\u00f3s {secret.YearsKept} anos: {secret.Secret}");
        return secret.Secret;
    }
}
