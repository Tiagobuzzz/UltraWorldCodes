using System;
using System.Collections.Generic;

namespace UltraWorldAI.Law;

public class Law
{
    public string Kingdom { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool IsActive { get; set; }
}

public static class RoyalLawSystem
{
    public static List<Law> Laws { get; } = new();

    public static void CreateLaw(string kingdom, string title, string desc)
    {
        Laws.Add(new Law
        {
            Kingdom = kingdom,
            Title = title,
            Description = desc,
            IsActive = true
        });

        Console.WriteLine($"📜 Lei criada em {kingdom}: {title} — {desc}");
    }

    public static void RevokeLaw(string title)
    {
        var l = Laws.Find(x => x.Title == title);
        if (l != null)
        {
            l.IsActive = false;
            Console.WriteLine($"🚫 Lei revogada: {l.Title}");
        }
    }

    public static void PrintLaws(string kingdom)
    {
        Console.WriteLine($"\n⚖️ Leis de {kingdom}:");
        foreach (var l in Laws)
            if (l.Kingdom == kingdom)
                Console.WriteLine($"• {l.Title} | Ativa: {l.IsActive} — {l.Description}");
    }
}
