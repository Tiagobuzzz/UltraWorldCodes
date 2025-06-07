using System;
using System.Collections.Generic;

namespace UltraWorldAI.Module15;

public class ExpressiveWork
{
    public string Author = string.Empty;
    public string Genre = string.Empty;
    public string Theme = string.Empty;
    public string Style = string.Empty;
}

public static class LiteraryExpressionSystem
{
    public static List<ExpressiveWork> Works { get; } = new();

    public static void CreateWork(string author, string genre, string theme, string style)
    {
        Works.Add(new ExpressiveWork
        {
            Author = author,
            Genre = genre,
            Theme = theme,
            Style = style
        });

        Console.WriteLine($"\u270d\ufe0f Obra liter\u00e1ria: {genre} | Autor: {author} | Tema: {theme} | Estilo: {style}");
    }
}
