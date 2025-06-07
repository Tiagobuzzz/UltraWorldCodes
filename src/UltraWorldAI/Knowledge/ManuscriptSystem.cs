using System;
using System.Collections.Generic;

namespace UltraWorldAI.Knowledge;

public class Manuscript
{
    public string Title = string.Empty;
    public string Author = string.Empty;
    public string Type = string.Empty; // "Livro", "Grim\u00f3rio", "Manuscrito"
    public int Year;
    public bool IsForbidden;
}

public static class ManuscriptSystem
{
    public static List<Manuscript> Library { get; } = new();

    public static void Create(
        string title,
        string author,
        string type,
        int year,
        bool forbidden)
    {
        Library.Add(new Manuscript
        {
            Title = title,
            Author = author,
            Type = type,
            Year = year,
            IsForbidden = forbidden
        });

        Console.WriteLine($"\uD83D\uDCD6 {type} criado: {title} por {author} ({year})");
    }
}
