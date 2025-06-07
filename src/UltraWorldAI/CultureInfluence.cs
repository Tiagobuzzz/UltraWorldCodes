using System;
using System.Linq;

namespace UltraWorldAI
{
    public static class CultureInfluence
    {
        public static void ApplyCultureToMind(Culture culture, Mind mind)
        {
            foreach (var value in culture.CoreValues)
            {
                mind.IdeaEngine.GenerateIdea($"Valor cultural: {value}", new() { value }, 0.4f, 0.6f);
            }

            foreach (var taboo in culture.Taboos)
            {
                mind.IdeaEngine.GenerateIdea($"Tabu presente: {taboo}", new() { taboo }, 0.6f, 0.5f);
            }

            foreach (var ritual in culture.Traditions.SelectMany(t => t.Rituals).Select(r => r.Name))
            {
                mind.IdeaEngine.GenerateIdea($"Ritual observado: {ritual}", new() { ritual }, 0.5f, 0.4f);
            }
        }

        public static void UpdateCultureFromMind(Mind mind, Culture culture)
        {
            var strongIdeas = mind.IdeaEngine.GeneratedIdeas
                .Where(i => i.IsExpressed && i.SymbolicPower > 0.7f)
                .Select(i => i.Title)
                .ToList();

            foreach (var idea in strongIdeas)
            {
                if (!culture.AssociatedIdeas.Contains(idea))
                {
                    culture.AssociatedIdeas.Add(idea);
                    culture.CoreValues.Add($"Expressão: {idea}");
                }
            }

            if (strongIdeas.Count > 3 && culture.Traditions.All(t => t.Name != "Ritual da Palavra Viva"))
            {
                culture.Traditions.Add(new CulturalTradition
                {
                    Name = "Ritual da Palavra Viva",
                    Purpose = "celebrar ideias",
                    OriginStory = "Influencia da mente",
                    Rituals = new()
                    {
                        new RitualInstance
                        {
                            Name = "Entoar a Palavra",
                            Date = DateTime.Now,
                            EmotionTone = "inspirado",
                            PerformedBy = mind.PersonReference.Name
                        }
                    }
                });
            }
        }
    }
}
