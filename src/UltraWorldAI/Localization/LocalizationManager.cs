using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace UltraWorldAI.Localization;

public static class LocalizationManager
{
    private static readonly Dictionary<string, Dictionary<string, string>> _cache = new();
    public static string CurrentLanguage { get; set; } = "en";

    public static void LoadLanguage(string lang, string path)
    {
        if (!File.Exists(path)) return;
        var text = File.ReadAllText(path);
        var data = JsonSerializer.Deserialize<Dictionary<string, string>>(text) ?? new();
        _cache[lang] = data;
    }

    public static string Translate(string key)
    {
        if (_cache.TryGetValue(CurrentLanguage, out var lang) && lang.TryGetValue(key, out var value))
            return value;
        if (_cache.TryGetValue("en", out var en) && en.TryGetValue(key, out var fallback))
            return fallback;
        return key;
    }
}
