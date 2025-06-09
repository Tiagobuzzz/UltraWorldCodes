using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace UltraWorldAI.Civilization;

/// <summary>
/// Provides persistence helpers for the CultureSystem.
/// </summary>
public static class CulturePersistence
{

    public static void Save(string path, List<Culture> cultures)
    {
        try
        {
            var json = JsonUtility.ToJson(cultures);
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
            return JsonUtility.FromJson<List<Culture>>(json) ?? new();
        }
        catch (IOException ex)
        {
            Logger.LogError($"Failed to load cultures from {path}", ex);
            return new();
        }
    }
}
