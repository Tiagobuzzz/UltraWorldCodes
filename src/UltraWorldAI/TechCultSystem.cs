using System;
using System.Collections.Generic;

namespace UltraWorldAI.Religion;

public class TechCult
{
    public string Name { get; set; } = string.Empty;
    public string OriginTech { get; set; } = string.Empty;
    public string Founder { get; set; } = string.Empty;
    public List<string> Beliefs { get; set; } = new();
    public string CentralRitual { get; set; } = string.Empty;
    public bool IsRadical { get; set; }
    public int Followers { get; set; }
}

public static class TechCultSystem
{
    public static List<TechCult> AllCults { get; } = new();

    public static TechCult CreateCult(string techName, string founder, string ritual, List<string> beliefs, bool radical)
    {
        var cult = new TechCult
        {
            Name = $"Culto de {techName}",
            OriginTech = techName,
            Founder = founder,
            CentralRitual = ritual,
            Beliefs = beliefs,
            IsRadical = radical,
            Followers = new Random().Next(100, 10000)
        };

        AllCults.Add(cult);
        return cult;
    }

    public static string ListAll()
    {
        if (AllCults.Count == 0) return "Nenhum culto tecnológico fundado ainda.";
        return string.Join("\n\n", AllCults.ConvertAll(c =>
            $"\uD83C\uDFAD {c.Name} (Fundado por {c.Founder})\nRitual: {c.CentralRitual}\nCrenças: {string.Join(", ", c.Beliefs)}\n" +
            $"Radical: {(c.IsRadical ? "⚠️ Sim" : "✅ Não")} | Seguidores: {c.Followers}"));
    }
}
