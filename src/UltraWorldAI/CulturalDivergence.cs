using System.Collections.Generic;
using System.Linq;

namespace UltraWorldAI;

public static class CulturalDivergence
{
    public static bool CheckForRupture(Mind mind, Culture culture, float threshold = 0.7f)
    {
        var conflictingIdeas = mind.IdeaEngine.GeneratedIdeas
            .Where(i => culture.Taboos.Any(t => i.Title.Contains(t.Description)) && i.SymbolicPower > threshold)
            .ToList();

        return conflictingIdeas.Count >= 2;
    }

    public static Culture CreateNewCultureFromRupture(Mind mind, Culture parentCulture)
    {
        string newName = $"{parentCulture.Name} (Fragmento de {mind.PersonReference.Name})";

        var newCulture = new Culture
        {
            Name = newName,
            CoreValues = mind.IdeaEngine.GeneratedIdeas
                .Where(i => i.IsExpressed && i.SymbolicPower > 0.5f)
                .Select(i => $"Herdeiro: {i.Title}")
                .ToList(),
            Taboos = new List<Taboo>
            {
                new() { Description = "Negacao da origem" },
                new() { Description = "Repetir o passado" }
            },
            Traditions = new List<Tradition>
            {
                TraditionEngine.CreateBasicTradition("Corte do Vinculo Ancestral")
            },
            AestheticStyle = "Estetica fragmentada",
            CalendarType = CalendarType.Emocional,
            AssociatedIdeas = mind.IdeaEngine.GeneratedIdeas.Select(i => i.Title).ToList(),
            CulturalCalendar = CalendarBuilder.CreateCalendar(CalendarType.Emocional)
        };

        return newCulture;
    }

    public static string DescribeRupture(Culture original, Culture nova)
    {
        return $"Cultura '{nova.Name}' nasceu da ruptura com '{original.Name}' e carrega {nova.CoreValues.Count} valores herdados.";
    }
}
