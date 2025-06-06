namespace UltraWorldAI.Language;

using System.Collections.Generic;
using System.Linq;

public class TranslationLayer
{
    private readonly Dictionary<string, string> _dictionary = new();

    public void AddRule(string original, string translated) => _dictionary[original] = translated;

    public string TranslateWord(string word) => _dictionary.TryGetValue(word, out var val) ? val : word;
}

public static class LanguageEngine
{
    private static readonly List<TranslationLayer> _layers = new();

    public static void Clear() => _layers.Clear();

    public static void AddLayer(TranslationLayer layer) => _layers.Add(layer);

    public static string Translate(string text)
    {
        foreach (var layer in _layers)
        {
            text = string.Join(' ', text.Split(' ').Select(layer.TranslateWord));
        }
        return text;
    }
}

