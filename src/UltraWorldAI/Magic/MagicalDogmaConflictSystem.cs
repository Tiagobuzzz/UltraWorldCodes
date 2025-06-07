using System;
using System.Collections.Generic;

namespace UltraWorldAI.Magic;

public class MagicalDogma
{
    public string Name = string.Empty;
    public string Philosophy = string.Empty; // "Magia é vida", "Magia deve ser contida", "Magia só em ritual"
    public List<string> OpposedDogmas = new();
    public bool IsMilitant;
}

public static class MagicalDogmaConflictSystem
{
    public static List<MagicalDogma> Dogmas { get; } = new();

    public static void AddDogma(string name, string philosophy, List<string> opposed, bool militant)
    {
        Dogmas.Add(new MagicalDogma
        {
            Name = name,
            Philosophy = philosophy,
            OpposedDogmas = opposed,
            IsMilitant = militant
        });

        Console.WriteLine($"\u2696\uFE0F Dogma: {name} | Filosofia: {philosophy} | Conflitos: {string.Join(", ", opposed)} | Militante: {militant}");
    }

    public static void PrintDogmas()
    {
        foreach (var d in Dogmas)
            Console.WriteLine($"\n\uD83D\uDCDC {d.Name} | Filosofia: {d.Philosophy} | Contra: {string.Join(", ", d.OpposedDogmas)} | Militante: {d.IsMilitant}");
    }
}
