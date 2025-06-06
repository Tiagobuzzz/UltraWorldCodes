using System.Collections.Generic;

namespace UltraWorldAI.ModScripting;

/// <summary>
/// Allows registration and execution of external mod scripts.
/// </summary>
public static class ModScriptEngine
{
    private static readonly List<IModScript> _scripts = new();

    public static void Register(IModScript script, ModContext context)
    {
        script.Initialize(context);
        _scripts.Add(script);
    }

    public static void ExecuteAll(ModContext context)
    {
        foreach (var script in _scripts)
            script.Execute(context);
    }

    public static void Clear() => _scripts.Clear();
}

