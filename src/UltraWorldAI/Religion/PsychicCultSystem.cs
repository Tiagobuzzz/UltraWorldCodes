using System;
using System.Collections.Generic;
using System.Linq;

namespace UltraWorldAI.Religion;

public class PsychicCult
{
    public string Name = string.Empty;
    public string WorshipedEntity = string.Empty;
    public List<string> Followers { get; } = new();
    public string Doctrine = string.Empty; // "Silêncio Mental", "Expansão da Dor", "Iluminação do Vazio"
}

public static class PsychicCultSystem
{
    public static List<PsychicCult> Cults { get; } = new();

    public static PsychicCult CreateCult(string entity, string doctrine)
    {
        var cult = new PsychicCult
        {
            Name = $"Ordem de {entity}",
            WorshipedEntity = entity,
            Doctrine = doctrine
        };

        Cults.Add(cult);
        Console.WriteLine($"\u26EA Culto criado: {cult.Name} | Doutrina: {doctrine}");
        return cult;
    }

    public static void JoinCult(string ai, string entity)
    {
        var cult = Cults.FirstOrDefault(c => c.WorshipedEntity == entity);
        if (cult != null && !cult.Followers.Contains(ai))
        {
            cult.Followers.Add(ai);
            Console.WriteLine($"\uD83D\uDE4F {ai} juntou-se à {cult.Name}");
        }
    }

    public static void LeaveCult(string ai, string entity)
    {
        var cult = Cults.FirstOrDefault(c => c.WorshipedEntity == entity);
        if (cult != null && cult.Followers.Remove(ai))
        {
            Console.WriteLine($"\uD83D\uDC4B {ai} deixou a {cult.Name}");
        }
    }

    public static string DescribeCult(string entity)
    {
        var cult = Cults.FirstOrDefault(c => c.WorshipedEntity == entity);
        if (cult == null) return "Culto não encontrado.";

        return $"\u26EA {cult.Name} | Doutrina: {cult.Doctrine} | Seguidores: {cult.Followers.Count}";
    }
}
