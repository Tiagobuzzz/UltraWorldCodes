using System.Collections.Generic;

namespace UltraWorldAI.Discovery;

public class ModularTech
{
    public string Name { get; set; } = string.Empty;
    public List<string> Modules { get; } = new();
    public string ResultFunction { get; set; } = string.Empty;
}

public static class TechModularity
{
    public static ModularTech CombineTechs(string newName, List<ConceptualTech> techs)
    {
        var modules = new List<string>();
        var finalFunction = string.Empty;

        foreach (var t in techs)
        {
            modules.Add(t.Name);
            finalFunction += $"[{t.HypotheticalFunction}] ";
        }

        return new ModularTech
        {
            Name = newName,
            Modules = modules,
            ResultFunction = finalFunction.Trim()
        };
    }
}
