using System;
using System.Collections.Generic;
using System.Linq;

namespace UltraWorldAI
{
    public static class TraditionEngine
    {
        public static CulturalTradition CreateBasicTradition(string inspiration)
        {
            return new CulturalTradition
            {
                Name = $"Tradicao {inspiration}",
                Purpose = "coesao",
                OriginStory = inspiration,
                Rituals = new List<RitualInstance>
                {
                    new()
                    {
                        Name = "Danca do Som Silencioso",
                        Date = DateTime.Now,
                        EmotionTone = "neutro",
                        PerformedBy = "sistema"
                    }
                }
            };
        }

        public static void AddTradition(Culture culture, CulturalTradition tradition)
        {
            if (culture.Traditions.All(t => t.Name != tradition.Name))
                culture.Traditions.Add(tradition);
        }

        public static void MutateTraditions(Culture culture)
        {
            foreach (var tradition in culture.Traditions)
            {
                for (int i = 0; i < tradition.Rituals.Count; i++)
                {
                    var ritual = tradition.Rituals[i];
                    if (ritual.Name.Contains("Danca"))
                    {
                        ritual.Name = ritual.Name.Replace("Danca", "Eco da Danca");
                    }
                }

                if (tradition.Rituals.All(r => r.Name != "Ritual da Sombra Lenta"))
                {
                    tradition.Rituals.Add(new RitualInstance
                    {
                        Name = "Ritual da Sombra Lenta",
                        Date = DateTime.Now,
                        EmotionTone = "neutro",
                        PerformedBy = "sistema"
                    });
                }
            }
        }

        public static string DescribeTraditions(Culture culture)
        {
            var rituals = culture.Traditions
                .SelectMany(t => t.Rituals)
                .Select(r => r.Name)
                .Distinct();

            return $"A cultura {culture.Name} mantem os rituais: {string.Join(", ", rituals)}";
        }
    }
}
