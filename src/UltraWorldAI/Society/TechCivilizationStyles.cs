using System.Collections.Generic;

namespace UltraWorldAI.Society;

public class CivilizationStyle
{
    public string Name { get; set; } = string.Empty;
    public string BasedOnTech { get; set; } = string.Empty;
    public List<string> Traits { get; set; } = new();
    public string GovernmentModel { get; set; } = string.Empty;
    public string CulturalTheme { get; set; } = string.Empty;
}

public static class TechCivilizationStyles
{
    public static List<CivilizationStyle> Styles { get; } = new();

    public static CivilizationStyle CreateStyle(string tech, string creator)
    {
        string gov = tech switch
        {
            var t when t.Contains("controle") => "Tecnocracia Centralizada",
            var t when t.Contains("ritual") => "Magocracia Espiritual",
            var t when t.Contains("arma") => "Feudalismo Militar",
            var t when t.Contains("rede") => "Tecnodemocracia Colaborativa",
            _ => "Tribo Simbolica Autonoma"
        };

        string theme = tech switch
        {
            var t when t.Contains("sangue") => "Cultura de Sacrificio",
            var t when t.Contains("memoria") => "Cultura Arquivista",
            var t when t.Contains("som") => "Cultura Musical",
            _ => "Cultura Adaptativa"
        };

        var traits = new List<string> { $"Tecnologia dominante: {tech}", $"Sistema: {gov}", $"Tema: {theme}" };

        var style = new CivilizationStyle
        {
            Name = $"Civilizacao de {creator}",
            BasedOnTech = tech,
            Traits = traits,
            GovernmentModel = gov,
            CulturalTheme = theme
        };

        Styles.Add(style);
        return style;
    }

    public static string ListAll()
    {
        if (Styles.Count == 0) return "Nenhum estilo civilizacional foi criado.";
        return string.Join("\n\n", Styles.ConvertAll(c =>
            $"\uD83C\uDFDB\uFE0F {c.Name}\nTecnologia: {c.BasedOnTech}\nGoverno: {c.GovernmentModel}\nCultura: {c.CulturalTheme}"));
    }
}
