using System;
using System.Collections.Generic;

namespace UltraWorldAI.Language;

public class LinguisticArt
{
    public string Title { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty; // Teatro, Canção, Poesia
    public string Creator { get; set; } = string.Empty;
    public string Language { get; set; } = string.Empty;
}

public static class LinguisticArtsSystem
{
    public static List<LinguisticArt> Works { get; } = new();

    public static void AddWork(string title, string type, string creator, string language)
    {
        Works.Add(new LinguisticArt
        {
            Title = title,
            Type = type,
            Creator = creator,
            Language = language
        });
    }

    public static void PrintWorks()
    {
        foreach (var w in Works)
        {
            Console.WriteLine($"\uD83C\uDFB6 {w.Type}: '{w.Title}' por {w.Creator} em {w.Language}");
        }
    }
}
