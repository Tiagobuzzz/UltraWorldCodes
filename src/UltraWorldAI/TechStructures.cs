using System.Collections.Generic;

namespace UltraWorldAI.Structures;

public class TechStructure
{
    public string Name { get; set; } = string.Empty;
    public string BasedOnTech { get; set; } = string.Empty;
    public string Creator { get; set; } = string.Empty;
    public string Function { get; set; } = string.Empty;
    public string SymbolicMeaning { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string Region { get; set; } = string.Empty;
}

public static class TechStructures
{
    public static List<TechStructure> AllStructures { get; } = new();

    public static TechStructure CreateStructure(string techName, string creator, string region, string type, string meaning)
    {
        var structure = new TechStructure
        {
            Name = $"{type} de {techName}",
            BasedOnTech = techName,
            Creator = creator,
            Function = $"Materializa função de {techName}",
            SymbolicMeaning = meaning,
            Type = type,
            Region = region
        };

        AllStructures.Add(structure);
        return structure;
    }

    public static string ListAll()
    {
        if (AllStructures.Count == 0) return "Nenhuma estrutura criada.";
        return string.Join("\n\n", AllStructures.ConvertAll(s =>
            $"\uD83C\uDFD7️ {s.Name} ({s.Type}) em {s.Region}\nPor: {s.Creator}\nFunção: {s.Function}\nSímbolo: {s.SymbolicMeaning}"));
    }
}
