using System.Linq;

namespace UltraWorldAI;

public static class CulturalCollapse
{
    public static bool CheckCollapse(Culture culture)
    {
        bool valuesEmpty = culture.CoreValues.Count == 0;
        bool ritualsForgotten = !culture.Traditions.Any() || culture.Traditions.All(t => t.Rituals.Count == 0);
        bool taboosContradictValues = culture.Taboos.Any(t => culture.CoreValues.Any(v => t.Contains(v)));

        return valuesEmpty || ritualsForgotten || taboosContradictValues;
    }

    public static void CollapseCulture(Culture culture)
    {
        culture.Name += " (Extinta)";
        culture.CoreValues.Clear();
        culture.Traditions.Clear();
        culture.Taboos.Clear();
        culture.AestheticStyle = "Ruína da memória";
        culture.CulturalCalendar = new Calendar(culture.CalendarType);
        culture.AssociatedIdeas.Add("Desintegração cultural");
    }

    public static string DescribeCollapse(Culture culture)
    {
        return $"A cultura '{culture.Name}' colapsou por perda simbólica e contradição ritual.";
    }
}
