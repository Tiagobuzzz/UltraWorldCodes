using System;
using System.Collections.Generic;
using System.Linq;

namespace UltraWorldAI
{
    public class ThoughtSystem
    {
        public List<Thought> CurrentThoughts { get; private set; } = new();
        private static readonly Random Random = new();

        public void GenerateThought(Mind brain)
        {
            if (Random.NextDouble() > brain.Personality.GetTrait("Curiosity"))
                return;

            string seedConcept = PickSeed(brain);
            string imaginedScenario = BuildImagination(seedConcept, brain);
            float relevance = EvaluateRelevance(imaginedScenario, brain);

            var thought = new Thought
            {
                Origin = seedConcept,
                Content = imaginedScenario,
                EmotionalWeight = (int)(brain.Emotions.GetEmotion("fear") * 5 - brain.Emotions.GetEmotion("happiness") * 3),
                Timestamp = DateTime.Now,
                RelevanceScore = relevance
            };

            CurrentThoughts.Add(thought);
            brain.Memory.AddMemory($"Pensou sobre: {imaginedScenario}", 0.3f, thought.EmotionalWeight);
        }

        private string PickSeed(Mind brain)
        {
            var memories = brain.Memory.RetrieveMemories(string.Empty, 1);
            var belief = brain.Beliefs.Beliefs.Keys.FirstOrDefault() ?? "mundo";
            var dominantEmotion = brain.Emotions.GetDominantEmotion();
            return $"{belief} + {dominantEmotion}";
        }

        private string BuildImagination(string seed, Mind brain)
        {
            var voice = brain.Subvoices.GetDominantVoice();
            var emotion = brain.Emotions.GetDominantEmotion();
            var goal = brain.Goals.ActiveGoals.FirstOrDefault()?.Description ?? "um futuro incerto";

            return $"{voice.Name} imagina: E se {goal.ToLower()} acontecer sob {seed.ToLower()}? Isso pode mudar tudo.";
        }

        private float EvaluateRelevance(string scenario, Mind brain)
        {
            float score = 0.1f;
            if (brain.Conflict.HasActiveContradictions())
                score += 0.3f;
            if (scenario.ToLower().Contains("medo") || scenario.ToLower().Contains("perda"))
                score += 0.2f;
            if (brain.Emotions.GetEmotion("love") > 0.6f)
                score += 0.15f;

            return Math.Min(1f, score);
        }

        public void DecayThoughts()
        {
            CurrentThoughts = CurrentThoughts
                .Where(t => (DateTime.Now - t.Timestamp).TotalMinutes < 60)
                .ToList();
        }

        public string GetMostRelevantThought()
        {
            return CurrentThoughts
                .OrderByDescending(t => t.RelevanceScore)
                .FirstOrDefault()?.Content ?? "Sem pensamentos marcantes no momento.";
        }
    }

    public class Thought
    {
        public string Origin { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public int EmotionalWeight { get; set; }
        public DateTime Timestamp { get; set; }
        public float RelevanceScore { get; set; }
    }
}
