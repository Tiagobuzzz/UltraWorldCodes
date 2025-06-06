using System;
using System.IO;
using System.Reflection;

namespace UltraWorldAI;

/// <summary>
/// Loads external assemblies to extend the simulation.
/// </summary>
public static class ModSupport
{
    public static void LoadMod(string path)
    {
        if (!File.Exists(path))
            return;
        Assembly.LoadFrom(path);
        Console.WriteLine($"Mod loaded: {Path.GetFileName(path)}");
    }
}
