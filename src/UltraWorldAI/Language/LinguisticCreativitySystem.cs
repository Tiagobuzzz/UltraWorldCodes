using System;
using System.Collections.Generic;

namespace UltraWorldAI.Language;

public class LinguisticCreation
{
    public string IAName { get; set; } = string.Empty;
    public string NativeLanguage { get; set; } = string.Empty;
    public List<string> NewWords { get; set; } = new();
    public List<string> BooksWritten { get; set; } = new();
    public string? DialectName { get; set; }
}

public static class LinguisticCreativitySystem
{
    public static List<LinguisticCreation> Creations { get; } = new();

    public static void RegisterCreator(string name, string language)
    {
        Creations.Add(new LinguisticCreation
        {
            IAName = name,
            NativeLanguage = language
        });
    }

    public static void InventWord(string name, string word)
    {
        var creator = Creations.Find(c => c.IAName == name);
        if (creator == null) return;
        creator.NewWords.Add(word);
        Console.WriteLine($"\uD83D\uDC64 {name} inventou a palavra '{word}' na l\u00EDngua {creator.NativeLanguage}");
    }

    public static void WriteBook(string name, string title)
    {
        var creator = Creations.Find(c => c.IAName == name);
        if (creator == null) return;
        creator.BooksWritten.Add(title);
        Console.WriteLine($"\uD83D\uDCD6 {name} escreveu o livro '{title}'");
    }

    public static void CreateDialect(string name, string dialect)
    {
        var creator = Creations.Find(c => c.IAName == name);
        if (creator == null) return;
        creator.DialectName = dialect;
        Console.WriteLine($"\uD83C\uDF00 {name} fundou o dialeto '{dialect}' a partir de {creator.NativeLanguage}");
    }
}
