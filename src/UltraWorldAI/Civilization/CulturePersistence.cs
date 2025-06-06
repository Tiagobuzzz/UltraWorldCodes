using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace UltraWorldAI.Civilization;

/// <summary>
/// Provides persistence helpers for the CultureSystem.
/// </summary>
public static class CulturePersistence
{
    private static readonly JsonSerializerOptions _options = new() { WriteIndented = false };

    public static void Save(string path, List<Culture> cultures)
    {
        var json = JsonSerializer.Serialize(cultures, _options);
        File.WriteAllText(path, json);
    }

    public static List<Culture> Load(string path)
    {
        if (!File.Exists(path)) return new();
        var json = File.ReadAllText(path);
        return JsonSerializer.Deserialize<List<Culture>>(json, _options) ?? new();
    }
}
