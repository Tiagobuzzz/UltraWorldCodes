using System.Collections.Generic;

namespace UltraWorldAI.Economy;

public class Profession
{
    public string Name { get; set; } = string.Empty;
    public string Tool { get; set; } = string.Empty;
    public string Output { get; set; } = string.Empty;
}

public class Invention
{
    public string Name { get; set; } = string.Empty;
    public string CreatedBy { get; set; } = string.Empty;
    public string Effect { get; set; } = string.Empty;
}

public static class ProfessionAndInnovationSystem
{
    public static List<Profession> Professions { get; } = new();
    public static List<Invention> Inventions { get; } = new();

    public static void RegisterProfession(string name, string tool, string output)
    {
        Professions.Add(new Profession { Name = name, Tool = tool, Output = output });
        Logger.Log($"[Profissao] {name} usa {tool} para criar {output}");
    }

    public static void RegisterInvention(string name, string creator, string effect)
    {
        Inventions.Add(new Invention { Name = name, CreatedBy = creator, Effect = effect });
        Logger.Log($"[Inovacao] {name} por {creator} | Efeito: {effect}");
    }

    public static IReadOnlyList<Profession> ListProfessions() => Professions;
    public static IReadOnlyList<Invention> ListInventions() => Inventions;
}
