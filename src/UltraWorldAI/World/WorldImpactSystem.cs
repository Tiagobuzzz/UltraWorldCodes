using System.Collections.Generic;

namespace UltraWorldAI.World;

public class WorldImpact
{
    public string TechName { get; set; } = string.Empty;
    public string Region { get; set; } = string.Empty;
    public string Effect { get; set; } = string.Empty;
    public string EnvironmentalSymbol { get; set; } = string.Empty;
}

public static class WorldImpactSystem
{
    public static List<WorldImpact> Impacts { get; } = new();

    public static void ApplyImpact(string techName, string region, string type)
    {
        string effect = type switch
        {
            "terra" => "O solo se tornou fertil/saturado",
            "clima" => "O clima local se aqueceu/resfriou",
            "cultura" => "Crencas e comportamentos mudaram",
            "fluxo" => "Rotas comerciais ou migratorias foram alteradas",
            _ => "Mudanca simbolica nao especificada"
        };

        Impacts.Add(new WorldImpact
        {
            TechName = techName,
            Region = region,
            Effect = effect,
            EnvironmentalSymbol = $"Marca simbolica de {techName}"
        });
    }

    public static string ListAll()
    {
        if (Impacts.Count == 0) return "Nenhuma tecnologia afetou o mundo ainda.";
        return string.Join("\n\n", Impacts.ConvertAll(i =>
            $"\uD83C\uDF0D {i.TechName} alterou {i.Region}\nEfeito: {i.Effect}\nSimbolo: {i.EnvironmentalSymbol}"));
    }
}
