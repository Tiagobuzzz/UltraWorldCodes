using System;
using System.Collections.Generic;

namespace UltraWorldAI.Language;

public class InventedAlphabet
{
    public string Name { get; set; } = string.Empty;
    public string Creator { get; set; } = string.Empty;
    public string Style { get; set; } = string.Empty; // Calligraphy style
    public string Value { get; set; } = string.Empty; // "Magico" ou "Social"
}

public static class AlphabetCreationSystem
{
    public static List<InventedAlphabet> Alphabets { get; } = new();

    public static void Invent(string ia, string name, string style, string value)
    {
        Alphabets.Add(new InventedAlphabet
        {
            Creator = ia,
            Name = name,
            Style = style,
            Value = value
        });
        Console.WriteLine($"\u270D\uFE0F {ia} criou o alfabeto '{name}' ({style}, valor {value})");
    }
}
