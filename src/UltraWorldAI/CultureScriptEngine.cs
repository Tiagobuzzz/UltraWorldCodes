using System.Collections.Generic;

namespace UltraWorldAI;

public interface ICultureScript
{
    string Name { get; }
    void Run(Culture culture);
}

public static class CultureScriptEngine
{
    private static readonly List<ICultureScript> _scripts = new();

    public static void Register(ICultureScript script)
    {
        _scripts.Add(script);
    }

    public static void Execute(Culture culture)
    {
        foreach (var script in _scripts)
            script.Run(culture);
    }

    public static void Clear() => _scripts.Clear();
}
