using System;
using System.Collections.Generic;

namespace UltraWorldAI.Language;

public class MagicWord
{
    public string Word { get; set; } = string.Empty;
    public string Purpose { get; set; } = string.Empty; // Artefato, Porta, Visao
}

public static class MagicAccessWordSystem
{
    public static List<MagicWord> Words { get; } = new();

    public static void RegisterWord(string word, string purpose)
    {
        Words.Add(new MagicWord { Word = word, Purpose = purpose });
        Console.WriteLine($"\uD83D\uDD12 Palavra magica '{word}' criada para {purpose}");
    }

    public static bool UseWord(string word, string purpose)
    {
        var w = Words.Find(x => x.Word == word && x.Purpose == purpose);
        if (w != null)
        {
            Console.WriteLine($"\uD83D\uDD13 {word} desbloqueia {purpose}");
            return true;
        }
        Console.WriteLine($"\u274C {word} falhou em {purpose}");
        return false;
    }
}
