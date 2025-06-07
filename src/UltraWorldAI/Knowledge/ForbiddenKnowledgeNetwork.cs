using System;
using System.Collections.Generic;

namespace UltraWorldAI.Knowledge;

public class SecretNetwork
{
    public string Name = string.Empty;
    public List<string> Members = new();
    public List<string> HiddenTopics = new();
    public string AccessMethod = string.Empty; // "Código", "Ritual", "Alinhamento ideológico"
    public List<string> PoliticalAlliances = new();
    public List<string> MagicalPacts = new();
    public List<string> SupportedRebellions = new();
}

public static class ForbiddenKnowledgeNetwork
{
    public static List<SecretNetwork> Networks { get; } = new();

    public static void CreateNetwork(string name, List<string> members, List<string> topics, string method)
    {
        Networks.Add(new SecretNetwork
        {
            Name = name,
            Members = members,
            HiddenTopics = topics,
            AccessMethod = method
        });

        Console.WriteLine($"\ud83d\udd75\ufe0f Rede secreta criada: {name} | Método de acesso: {method} | Saberes ocultos: {topics.Count}");
    }

    public static void InfluencePolitics(string name, string faction)
    {
        var net = Networks.Find(n => n.Name == name);
        if (net == null) return;
        if (!net.PoliticalAlliances.Contains(faction))
            net.PoliticalAlliances.Add(faction);

        Console.WriteLine($"\ud83c\udfdb\ufe0f Rede {name} influenciou a política de {faction}");
    }

    public static void ForgeMagicalPact(string name, string pact)
    {
        var net = Networks.Find(n => n.Name == name);
        if (net == null) return;
        if (!net.MagicalPacts.Contains(pact))
            net.MagicalPacts.Add(pact);

        Console.WriteLine($"\u2728 Rede {name} selou pacto mágico: {pact}");
    }

    public static void SupportRebellion(string name, string rebellion)
    {
        var net = Networks.Find(n => n.Name == name);
        if (net == null) return;
        if (!net.SupportedRebellions.Contains(rebellion))
            net.SupportedRebellions.Add(rebellion);

        Console.WriteLine($"\u2694\ufe0f Rede {name} apoiou rebelião: {rebellion}");
    }
}
