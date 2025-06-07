using System;
using System.Collections.Generic;
using System.Linq;

namespace UltraWorldAI.Module16;

public class PsychicCult
{
    public string Name = string.Empty;
    public string Entity = string.Empty;
    public List<string> Members = new();
    public float DevotionLevel;
}

public static class PsychicCultSystem
{
    public static List<PsychicCult> Cults { get; } = new();

    public static void CreateCult(string name, string entity)
    {
        Cults.Add(new PsychicCult { Name = name, Entity = entity, DevotionLevel = 0.5f });
        Console.WriteLine($"\uD83C\uDF0D Culto '{name}' fundado em torno de {entity}");
    }

    public static void RecruitMember(string cultName, string member)
    {
        var cult = Cults.FirstOrDefault(c => c.Name == cultName);
        if (cult == null) return;
        cult.Members.Add(member);
        cult.DevotionLevel = Math.Min(1f, cult.DevotionLevel + 0.05f);
        Console.WriteLine($"\uD83D\uDD2C {member} ingressou no culto {cultName}");
    }
}
