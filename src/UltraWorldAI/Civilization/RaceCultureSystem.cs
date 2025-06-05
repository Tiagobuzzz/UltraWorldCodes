using System.Collections.Generic;

namespace UltraWorldAI.Civilization;

public class CulturalProfile
{
    public string RaceName { get; set; } = string.Empty;
    public List<string> PreferredProfessions { get; set; } = new();
    public string SocialStructure { get; set; } = string.Empty;
    public string ArtStyle { get; set; } = string.Empty;
    public string CommunicationMode { get; set; } = string.Empty;
    public string SocialNorms { get; set; } = string.Empty;
}

public static class RaceCultureSystem
{
    public static List<CulturalProfile> Profiles { get; private set; } = new();

    public static void GenerateAll()
    {
        Profiles = new()
        {
            new CulturalProfile
            {
                RaceName = "Humanos",
                PreferredProfessions = new() { "Construtor", "Comerciante", "Explorador" },
                SocialStructure = "Monarquia ou Democracia Emergente",
                ArtStyle = "Narrativa e Escultura",
                CommunicationMode = "Oratória e Escrita",
                SocialNorms = "Contrato Social, Moralidade Adaptativa"
            },
            new CulturalProfile
            {
                RaceName = "Elfos",
                PreferredProfessions = new() { "Guardião Natural", "Místico", "Músico" },
                SocialStructure = "Conselhos Eternos",
                ArtStyle = "Música Etérea, Pintura Bioluminescente",
                CommunicationMode = "Telepatia, Rituais",
                SocialNorms = "Equilíbrio, Estética e Harmonia"
            },
            new CulturalProfile
            {
                RaceName = "Anões",
                PreferredProfessions = new() { "Ferreiro", "Minerador", "Engenheiro" },
                SocialStructure = "Clãs Patriarcais",
                ArtStyle = "Metalurgia Artística e Runas",
                CommunicationMode = "Tambores, Códigos e Tatuagens",
                SocialNorms = "Honra, Precisão, Herança"
            },
            new CulturalProfile
            {
                RaceName = "Gigantes",
                PreferredProfessions = new() { "Caçador Solar", "Oráculo de Rocha" },
                SocialStructure = "Círculos Temporais",
                ArtStyle = "Cânticos Tectônicos",
                CommunicationMode = "Eco Profundo",
                SocialNorms = "Força, Silêncio e Legado"
            },
            new CulturalProfile
            {
                RaceName = "Fae",
                PreferredProfessions = new() { "Ilusionista", "Colhedor de Névoa", "Contador de Histórias" },
                SocialStructure = "Coletivos Temporários",
                ArtStyle = "Efêmero e Fluido",
                CommunicationMode = "Dança, Aroma, Imagem",
                SocialNorms = "Instinto, Caos Poético"
            }
        };
    }

    public static CulturalProfile? GetForRace(string race)
    {
        return Profiles.Find(p => p.RaceName == race);
    }

    public static string Describe(string race)
    {
        var c = GetForRace(race);
        if (c == null) return "Cultura não definida.";
        return $"🏛️ {c.RaceName}\nEstrutura: {c.SocialStructure}\nProfissões: {string.Join(", ", c.PreferredProfessions)}\n" +
               $"Arte: {c.ArtStyle} | Comunicação: {c.CommunicationMode}\nNormas: {c.SocialNorms}";
    }
}
