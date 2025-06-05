using System;
using System.Linq;

namespace UltraWorldAI;

public static class CulturalReformation
{
    public static void AttemptReformation(Mind mind, Culture culture)
    {
        var reformers = mind.IdeaEngine.GeneratedIdeas
            .Where(i => i.IsExpressed && i.SymbolicPower > 0.6f)
            .ToList();

        foreach (var idea in reformers)
        {
            bool isTaboo = culture.Taboos.Any(t => idea.Title.Contains(t));

            if (!isTaboo && !culture.CoreValues.Contains(idea.Title))
            {
                culture.CoreValues.Add(idea.Title);
                if (culture.Traditions.All(t => t.Name != $"Celebracao da Ideia: {idea.Title}"))
                {
                    var tradition = new Tradition
                    {
                        Name = $"Celebracao da Ideia: {idea.Title}",
                        Purpose = "celebrar inovacao",
                        OriginStory = idea.Title,
                        Rituals = new()
                        {
                            new RitualInstance
                            {
                                Name = $"Refletir sobre {idea.Title}",
                                Date = DateTime.Now,
                                EmotionTone = "inspirado",
                                PerformedBy = mind.PersonReference.Name
                            }
                        }
                    };
                    culture.Traditions.Add(tradition);
                }
            }
            else if (isTaboo)
            {
                mind.Stress.AddStress(0.1f);
            }
        }

        if (culture.CoreValues.Count > 7 && culture.Traditions.All(t => t.Name != "Festa da Nova Consciencia"))
        {
            var fest = new Tradition
            {
                Name = "Festa da Nova Consciencia",
                Purpose = "marcar reforma cultural",
                OriginStory = "acumulo de reformas",
                Rituals = new()
                {
                    new RitualInstance
                    {
                        Name = "Celebracoes Continuas",
                        Date = DateTime.Now,
                        EmotionTone = "festivo",
                        PerformedBy = "sistema"
                    }
                }
            };
            culture.Traditions.Add(fest);
        }
    }
}
