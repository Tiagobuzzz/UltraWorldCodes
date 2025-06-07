using System;
using System.Collections.Generic;

namespace UltraWorldAI.Module15;

public class LiteraryWork
{
    public string Author = string.Empty;
    public string Form = string.Empty; // poema, teatro, etc.
    public string Tone = string.Empty; // sarc\u00E1stico, ir\u00F4nico
    public string Excerpt = string.Empty;
}

public static class LiteraryCreationSystem
{
    public static List<LiteraryWork> Works { get; } = new();

    public static void Write(string author, string form, string tone, string excerpt)
    {
        Works.Add(new LiteraryWork
        {
            Author = author,
            Form = form,
            Tone = tone,
            Excerpt = excerpt
        });

        Console.WriteLine($"\uD83D\uDCDD {author} escreveu {form} ({tone})");
    }

    public static void PrintWorks()
    {
        foreach (var w in Works)
            Console.WriteLine($"\uD83D\uDCD6 {w.Author} \u2013 {w.Form} ({w.Tone}): {w.Excerpt}");
    }
}
