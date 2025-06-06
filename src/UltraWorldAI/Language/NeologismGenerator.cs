using System;
using System.Linq;

namespace UltraWorldAI.Language;

public static class NeologismGenerator
{
    private static readonly Random _rand = new();

    public static string InventWord(Language lang, int length = 4)
    {
        if (lang.Phonemes.Count == 0 || length <= 0) return string.Empty;
        var word = string.Concat(Enumerable.Range(0, length)
            .Select(_ => lang.Phonemes[_rand.Next(lang.Phonemes.Count)]));
        return word;
    }
}
