using System;
using System.Collections.Generic;

namespace UltraWorldAI.Literature;

public class LostLibrary
{
    public string Name { get; set; } = string.Empty;
    public bool ContainsGrimoire { get; set; }
    public string Cipher { get; set; } = string.Empty; // Tipo de cifragem
    public bool IsLost { get; set; }
}

public static class LostLibrarySystem
{
    public static List<LostLibrary> Libraries { get; } = new();

    public static void AddLibrary(string name, bool grimoire, string cipher)
    {
        Libraries.Add(new LostLibrary
        {
            Name = name,
            ContainsGrimoire = grimoire,
            Cipher = cipher
        });
        Console.WriteLine($"\uD83D\uDCDA Biblioteca registrada: {name} (Grim\u00f3rio: {grimoire})");
    }

    public static void MarkLost(string name)
    {
        var lib = Libraries.Find(l => l.Name == name);
        if (lib == null) return;
        lib.IsLost = true;
        Console.WriteLine($"\uD83D\uDD25 Biblioteca perdida: {name}");
    }

    public static void PrintLibraries()
    {
        foreach (var l in Libraries)
        {
            Console.WriteLine($"\n\uD83C\uDFDB\uFE0F {l.Name} | Perdida: {l.IsLost} | Grim\u00f3rio: {l.ContainsGrimoire} | Cifra: {l.Cipher}");
        }
    }
}
