using System;
using System.Collections.Generic;
using System.Linq;

namespace UltraWorldAI
{
    public class TraditionSystem
    {
        public List<Tradition> Traditions { get; } = new();
        public List<RitualInstance> RitualHistory { get; } = new();

        public void CreateTradition(string inspiration, string purpose, string originMemory)
        {
            var tradition = new Tradition
            {
                Name = $"Tradicao de {inspiration}",
                Purpose = purpose,
                OriginStory = originMemory,
                Rituals = new List<RitualInstance>()
            };

            Traditions.Add(tradition);
        }

        public void PerformRitual(string name, Person performer, EmotionSystem emotionalState, string type = "")
        {
            var ritual = new RitualInstance
            {
                Name = name,
                Date = DateTime.Now,
                EmotionTone = emotionalState.GetDominantEmotion(),
                PerformedBy = performer.Name,
                Type = type
            };

            RitualHistory.Add(ritual);
            performer.Mind.Memory.AddMemory(
                $"Participou do ritual '{name}' ligado a tradição emocional: {ritual.EmotionTone}",
                0.3f,
                0f,
                new() { "Tradicao" },
                "ritual");

            if (Traditions.Any())
                Traditions.Last().Rituals.Add(ritual);
        }

        public List<string> GetTraditionNames() => Traditions.Select(t => t.Name).ToList();
    }

    public class Tradition
    {
        public string Name { get; set; } = string.Empty;
        public string Purpose { get; set; } = string.Empty;
        public string OriginStory { get; set; } = string.Empty;
        public List<RitualInstance> Rituals { get; set; } = new();
    }

    public class RitualInstance
    {
        public string Name { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string EmotionTone { get; set; } = string.Empty;
        public string PerformedBy { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
    }
}
