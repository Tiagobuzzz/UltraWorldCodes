using System.Collections.Generic;

namespace UltraWorldAI.Patching;

public class Patch
{
    public string Version { get; set; } = string.Empty;
    public List<string> Notes { get; } = new();
}

/// <summary>
/// Generates simple patch notes given version changes.
/// </summary>
public static class PatchGenerator
{
    public static Patch Generate(string fromVersion, string toVersion, List<string> changes)
    {
        var patch = new Patch { Version = $"{fromVersion}->{toVersion}" };
        patch.Notes.AddRange(changes);
        return patch;
    }
}
