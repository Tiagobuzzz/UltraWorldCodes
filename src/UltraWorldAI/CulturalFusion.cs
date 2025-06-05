using System;
using System.Collections.Generic;
using System.Linq;

namespace UltraWorldAI
{
    public static class CulturalFusion
    {
        public static Culture FuseCultures(Culture a, Culture b)
        {
            var fusion = new Culture
            {
                Name = $"{a.Name}-{b.Name} (Fusão)",
                CoreValues = a.CoreValues.Union(b.CoreValues).Distinct().ToList(),
                Taboos = a.Taboos.Union(b.Taboos).Distinct().ToList(),
                Traditions = a.Traditions.Concat(b.Traditions)
                    .GroupBy(t => t.Name)
                    .Select(g => g.First()).ToList(),
                AestheticStyle = $"{a.AestheticStyle} fundida com {b.AestheticStyle}",
                CalendarType = MergeCalendars(a.CalendarType, b.CalendarType),
                AssociatedIdeas = a.AssociatedIdeas.Union(b.AssociatedIdeas).Distinct().ToList(),
                CulturalCalendar = CalendarBuilder.CreateCalendar(a.CalendarType)
            };

            if (a.CalendarType != b.CalendarType)
            {
                var otherCal = CalendarBuilder.CreateCalendar(b.CalendarType);
                fusion.CulturalCalendar.Months = fusion.CulturalCalendar.Months.Union(otherCal.Months).ToList();
            }

            return fusion;
        }

        private static CalendarType MergeCalendars(CalendarType calA, CalendarType calB)
        {
            return calA == calB ? calA : calA;
        }

        public static string DescribeFusion(Culture fusion)
        {
            return $"Nova cultura formada: {fusion.Name}. Mistura de rituais, tabus e valores.";
        }
    }
}
