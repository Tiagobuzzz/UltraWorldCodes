using System;
using System.Collections.Generic;
using System.Linq;

namespace UltraWorldAI
{
    public class IntuitionSystem
    {
        public List<Insight> Insights { get; } = new();

        public void GenerateInsight(Mind brain)
        {
            var seedIdeas = brain.BrainMap.GetAssociatedIdeas(brain.Emotions.GetDominantEmotion());
            if (seedIdeas.Count == 0)
                return;

            var theme = seedIdeas[0].Split(' ')[0];
            var insight = new Insight
            {
                Statement = $"Talvez a verdade esteja em {theme}",
                EmotionBasis = brain.Emotions.GetDominantEmotion(),
                Confidence = 0.4f + brain.Personality.GetTrait("Curiosity") * 0.6f,
                Source = "Intuição emocional"
            };

            brain.Memory.AddMemory($"Insight: {insight.Statement}", insight.Confidence, 0f, new() { "Insight" }, "insight");
            Insights.Add(insight);
        }

        public List<Insight> GetCoreBeliefs()
        {
            return Insights.Where(i => i.Confidence > 0.6f).ToList();
        }

        public void ReinforceInsight(string statement, float amount = 0.05f)
        {
            var target = Insights.FirstOrDefault(i => i.Statement == statement);
            if (target != null)
                target.Confidence = Math.Min(1f, target.Confidence + amount);
        }
    }

    public class Insight
    {
        public string Statement { get; set; } = string.Empty;
        public string EmotionBasis { get; set; } = string.Empty;
        public float Confidence { get; set; }
        public string Source { get; set; } = string.Empty;
    }
}
