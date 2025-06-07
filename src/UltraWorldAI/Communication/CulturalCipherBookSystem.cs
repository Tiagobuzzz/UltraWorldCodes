using System;
using System.Collections.Generic;

namespace UltraWorldAI.Communication;

public class SecretBook
{
    public string Title { get; set; } = string.Empty;
    public string Culture { get; set; } = string.Empty;
    public Dictionary<string, string> Vocabulary { get; set; } = new();
    public string EncodedText { get; set; } = string.Empty;
}

public static class CulturalCipherBookSystem
{
    public static List<SecretBook> Books { get; } = new();

    public static void AddBook(string title, string culture, Dictionary<string, string> vocab, string text)
    {
        var words = text.Split(' ');
        for (var i = 0; i < words.Length; i++)
        {
            if (vocab.ContainsKey(words[i]))
                words[i] = vocab[words[i]];
        }

        Books.Add(new SecretBook
        {
            Title = title,
            Culture = culture,
            Vocabulary = vocab,
            EncodedText = string.Join(" ", words)
        });

        Console.WriteLine($"\uD83D\uDCD6 Livro secreto criado: {title} | Cultura: {culture}");
    }

    public static string? ReadBook(string title, string culture)
    {
        var book = Books.Find(b => b.Title == title);
        if (book == null) return null;

        if (book.Culture != culture)
        {
            Console.WriteLine($"\u274C {culture} n\u00e3o consegue decifrar o livro '{title}'.");
            return null;
        }

        var decoded = Decode(book.EncodedText, book.Vocabulary);
        Console.WriteLine($"\uD83D\uDCDA Conte\u00fado decifrado de '{title}': {decoded}");
        return decoded;
    }

    private static string Decode(string text, Dictionary<string, string> vocab)
    {
        var reverse = new Dictionary<string, string>();
        foreach (var kv in vocab)
            reverse[kv.Value] = kv.Key;

        var words = text.Split(' ');
        for (var i = 0; i < words.Length; i++)
        {
            if (reverse.ContainsKey(words[i]))
                words[i] = reverse[words[i]];
        }

        return string.Join(" ", words);
    }
}
