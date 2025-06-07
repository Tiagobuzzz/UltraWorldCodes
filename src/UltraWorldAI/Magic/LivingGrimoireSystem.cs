using System;
using System.Collections.Generic;

namespace UltraWorldAI.Magic;

public class Grimoire
{
    public string Title = string.Empty;
    public bool IsSentient;
    public List<string> ForbiddenWords = new();
    public string GlyphBehavior = string.Empty; // "Sangra ao ser aberto", "Grita verdades", etc.
}

public static class LivingGrimoireSystem
{
    public static List<Grimoire> Grimoires { get; } = new();

    public static void CreateGrimoire(string title, bool sentient, List<string> forbiddenWords, string glyphBehavior)
    {
        Grimoires.Add(new Grimoire
        {
            Title = title,
            IsSentient = sentient,
            ForbiddenWords = forbiddenWords,
            GlyphBehavior = glyphBehavior
        });

        Console.WriteLine($"\uD83D\uDCD6 Grim\u00F3rio: {title} | Vivo: {sentient} | Glifos: {glyphBehavior}");
    }

    public static void PrintGrimoires()
    {
        foreach (var g in Grimoires)
            Console.WriteLine($"\n\uD83D\uDCD3 {g.Title} | Sentiente? {g.IsSentient} | Glifos: {g.GlyphBehavior} | Palavras proibidas: {string.Join(", ", g.ForbiddenWords)}");
    }
}
