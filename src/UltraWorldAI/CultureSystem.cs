using System;
using System.Collections.Generic;
using System.Linq;

namespace UltraWorldAI
{
    public class Culture
    {
        public string Name { get; set; } = string.Empty;
        public List<string> CoreValues { get; set; } = new();
        public List<string> Taboos { get; set; } = new();
        public List<Tradition> Traditions { get; set; } = new();
        public string AestheticStyle { get; set; } = string.Empty;
        public CalendarType CalendarType { get; set; } = CalendarType.Lunar;
        public List<string> AssociatedIdeas { get; set; } = new();
        public Calendar CulturalCalendar { get; set; } = new(CalendarType.Lunar);
        public List<Festival> Festivals { get; set; } = new();
    }

    public class Festival
    {
        public string Name { get; set; } = string.Empty;
        public string Season { get; set; } = string.Empty;
    }

    public class CultureSystem
    {
        private readonly Random _random = new();
        public List<Culture> Cultures { get; } = new();

        public Culture CreateCultureFromIdea(string ideaTitle, List<string> keywords)
        {
            var culture = new Culture
            {
                Name = $"Cultura de {ideaTitle}",
                CoreValues = keywords.Take(3).ToList(),
                AestheticStyle = "mutável",
                CalendarType = CalendarType.Lunar,
                AssociatedIdeas = new List<string> { ideaTitle },
                CulturalCalendar = CalendarBuilder.CreateCalendar(CalendarType.Lunar)
            };

            var baseTradition = TraditionEngine.CreateBasicTradition(ideaTitle);
            culture.Traditions.Add(baseTradition);

            Cultures.Add(culture);
            return culture;
        }

        public void AbsorbLocalCulture(Person person)
        {
            if (!Cultures.Any()) return;
            var culture = Cultures[_random.Next(Cultures.Count)];
            foreach (var value in culture.CoreValues)
            {
                person.Mind.Beliefs.UpdateBelief(value, 0.1f);
            }
        }

        public void Update(Mind mind)
        {
            if (mind.IdeaEngine.GeneratedIdeas.Any() && _random.NextDouble() < 0.05)
            {
                var idea = mind.IdeaEngine.GeneratedIdeas.Last();
                CreateCultureFromIdea(idea.Title, idea.AssociatedMemories);
            }
            EvolveCultures();
        }

        private void EvolveCultures()
        {
            foreach (var culture in Cultures.ToList())
            {
                if (_random.NextDouble() < 0.1)
                {
                    culture.CoreValues.Add($"valor{_random.Next(100)}");
                }
                if (_random.NextDouble() < 0.05 && culture.CoreValues.Count > 1)
                {
                    var newCulture = CultureInheritance.InheritCulture(culture);
                    newCulture.Name = $"{culture.Name} Cisma";
                    newCulture.CoreValues.RemoveAt(0);
                    Cultures.Add(newCulture);
                }

                TraditionEngine.MutateTraditions(culture);
            }
        }
    }
}
