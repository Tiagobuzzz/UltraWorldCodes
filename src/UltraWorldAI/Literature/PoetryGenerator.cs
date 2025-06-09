using System;
using System.Linq;

namespace UltraWorldAI.Literature;

/// <summary>
/// Simple poetry generator used by the game for creative text.
/// </summary>
public static class PoetryGenerator
{
    private static readonly string[] _templates = new[]
    {
        "{0}, {1} e {2},\n{3}",
        "Sob {0},\n{1} {2}\n{3}",
        "Quando {0} acontece,\n{1} envolve {2}\n{3}"
    };

    private static readonly string[] _fillers = new[]
    {
        "o vento sussurra",
        "a noite se expande",
        "os sonhos se movem",
        "um segredo floresce"
    };

    public static string GeneratePoem(string theme)
    {
        var rnd = new Random();
        var template = _templates[rnd.Next(_templates.Length)];
        var words = _fillers.OrderBy(_ => rnd.Next()).Take(3).ToArray();
        return string.Format(template, theme, words[0], words[1], words[2]);
    }
}
