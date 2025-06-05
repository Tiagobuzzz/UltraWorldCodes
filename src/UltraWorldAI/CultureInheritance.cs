using System.Collections.Generic;

namespace UltraWorldAI
{
    public static class CultureInheritance
    {
        public static Culture InheritCulture(Culture parent)
        {
            return new Culture
            {
                Name = parent.Name + " Herdeira",
                CoreValues = new List<string>(parent.CoreValues),
                AestheticStyle = parent.AestheticStyle,
                CalendarType = parent.CalendarType,
                AssociatedIdeas = new List<string>(parent.AssociatedIdeas),
                CulturalCalendar = CalendarBuilder.CreateCalendar(parent.CalendarType)
            };
        }
    }
}
