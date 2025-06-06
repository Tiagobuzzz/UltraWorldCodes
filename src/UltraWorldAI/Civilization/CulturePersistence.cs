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
        try
        {
            var json = JsonSerializer.Serialize(cultures, _options);
            File.WriteAllText(path, json);
        }
        catch (IOException ex)
        {
            Logger.LogError($"Failed to save cultures to {path}", ex);
        }
    }

    public static List<Culture> Load(string path)
    {
        if (!File.Exists(path)) return new();
        try
        {
            var json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<List<Culture>>(json, _options) ?? new();
        }
        catch (IOException ex)
        {
            Logger.LogError($"Failed to load cultures from {path}", ex);
            return new();
        }
    }
}
