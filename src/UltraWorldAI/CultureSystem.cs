using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace UltraWorldAI
{
    public class Culture
    {
        public string Name { get; set; } = string.Empty;
        public string OriginStory { get; set; } = string.Empty;
        public List<string> CoreValues { get; set; } = new();
        public List<string> Taboos { get; set; } = new();
        public List<CulturalTradition> Traditions { get; set; } = new();
        public string AestheticStyle { get; set; } = string.Empty;
        public CalendarType CalendarType { get; set; } = CalendarType.Lunar;
        public List<string> AssociatedIdeas { get; set; } = new();
        public Calendar CulturalCalendar { get; set; } = new(CalendarType.Lunar);
        public List<Festival> Festivals { get; set; } = new();
        public List<string> SacredForms { get; set; } = new();
        /// <summary>
        /// Memories shared collectively by members of the culture.
        /// </summary>
        [JsonInclude]
        public MemorySystem CollectiveMemory { get; private set; } = new();
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
                OriginStory = GenerateOriginStory(ideaTitle),
                CoreValues = keywords.Take(3).ToList(),
                AestheticStyle = "mutável",
                CalendarType = CalendarType.Lunar,
                AssociatedIdeas = new List<string> { ideaTitle },
                CulturalCalendar = CalendarBuilder.CreateCalendar(CalendarType.Lunar)
            };

            var baseTradition = TraditionEngine.CreateBasicTradition(ideaTitle);
            culture.Traditions.Add(baseTradition);

            CultureScriptEngine.Execute(culture);

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
            EvolveCultures(mind);
        }

        /// <summary>
        /// Records a shared memory for the specified culture.
        /// </summary>
        public void AddCollectiveMemory(string cultureName, string summary, float intensity = 0.5f,
            float emotionalCharge = 0f, List<string>? keywords = null)
        {
            var culture = Cultures.FirstOrDefault(c => c.Name == cultureName);
            culture?.CollectiveMemory.AddMemory(summary, intensity, emotionalCharge, keywords, "collective");
        }

        public void PropagateBelief(string statement, string cultureName)
        {
            var culture = Cultures.FirstOrDefault(c => c.Name == cultureName);
            if (culture == null) return;

            if (!culture.CoreValues.Contains(statement))
                culture.CoreValues.Add(statement);

            AddCollectiveMemory(cultureName, statement, 0.4f, 0.2f, new() { "crença" });
        }

        public void DeclareSacredForm(string form)
        {
            foreach (var culture in Cultures)
            {
                if (!culture.SacredForms.Contains(form))
                    culture.SacredForms.Add(form);
            }
        }

        private void EvolveCultures(Mind mind)
        {
            foreach (var culture in Cultures.ToList())
            {
                if (CulturalDivergence.CheckForRupture(mind, culture))
                {
                    var fragment = CulturalDivergence.CreateNewCultureFromRupture(mind, culture);
                    Cultures.Add(fragment);
                }

                CulturalReformation.AttemptReformation(mind, culture);

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

        private static string GenerateOriginStory(string seed)
        {
            var rand = new Random(seed.GetHashCode());
            var myth = new[]
            {
                "formada a partir de um pacto ancestral",
                "nascida de um êxodo espiritual",
                "fundada após uma grande visão coletiva",
                "originada em uma jornada através de terras místicas",
                "erguida sobre ruínas esquecidas"
            };

            return $"Esta cultura foi {myth[rand.Next(myth.Length)]} inspirada pela ideia '{seed}'.";
        }
    }
}
