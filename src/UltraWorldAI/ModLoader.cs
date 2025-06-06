using System;
using System.Collections.Generic;
using System.IO;

namespace UltraWorldAI;

/// <summary>
/// Very simple mod loader that reads assemblies from a folder.
/// </summary>
public static class ModLoader
{
    public static List<string> LoadedMods { get; } = new();

    public static void LoadMods(string folder)
    {
        if (!Directory.Exists(folder)) return;
        foreach (var file in Directory.GetFiles(folder, "*.dll"))
        {
            LoadedMods.Add(Path.GetFileNameWithoutExtension(file));
        }
    }
}
