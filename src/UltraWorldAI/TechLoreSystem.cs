using System;
using UltraWorldAI;

namespace UltraWorldAI.Discovery;

public class TechLore
{
    public string TechName { get; set; } = string.Empty;
    public string CreatedBy { get; set; } = string.Empty;
    public string MomentOfCreation { get; set; } = string.Empty;
    public string FirstUse { get; set; } = string.Empty;
    public string CulturalReaction { get; set; } = string.Empty;
}

public static class TechLoreSystem
{
    private static readonly string[] CreationMoments =
    {
        "um colapso espiritual", "uma tempestade simbolica",
        "um ritual de fogo", "um grito silencioso", "um sonho lucido"
    };

    private static readonly string[] Uses =
    {
        "para salvar uma crianca", "para conquistar um templo",
        "num duelo sagrado", "num pacto entre racas", "num funeral coletivo"
    };

    private static readonly string[] Reactions =
    {
        "foi adorada por geracoes", "foi queimada como heresia",
        "se tornou tabu em cinco culturas", "virou um simbolo de paz",
        "foi esquecida e depois redescoberta"
    };


    public static string GenerateLore(ConceptualTech tech)
    {
        return $"\u2699 Lenda de {tech.Name}:\n" +
               $"Criada por {tech.CreatedBy} durante {RandomPick(CreationMoments)}.\n" +
               $"Primeiro uso: {RandomPick(Uses)}.\n" +
               $"Reacao cultural: {RandomPick(Reactions)}";
    }

    private static string RandomPick(string[] options) => options[RandomProvider.Next(0, options.Length)];
}
