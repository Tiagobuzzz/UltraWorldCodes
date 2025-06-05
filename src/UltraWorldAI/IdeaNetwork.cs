using System;
using System.Collections.Generic;
using System.Linq;

namespace UltraWorldAI
{
    /// <summary>
    /// Stores abstract ideas generated from memories, beliefs and emotions.
    /// Brainwires link sources to ideas with a strength value so we can
    /// surface the most influential thoughts.
    /// </summary>
    public class IdeaNetwork
    {
        public List<Idea> Ideas { get; private set; } = new();
        public List<Brainwire> Brainwires { get; private set; } = new();
        private readonly Random _rand = new();

        public void GenerateNewIdea(string seed, EmotionSystem emotions, MemorySystem memory, BeliefSystem beliefs)
        {
            var related = memory.Memories
                .Where(m => m.Summary.Contains(seed, StringComparison.OrdinalIgnoreCase))
                .ToList();

            string emotionalContext = emotions.GetDominantEmotion();
            string beliefInfluence = beliefs.Beliefs.Keys.FirstOrDefault(b => seed.Contains(b, StringComparison.OrdinalIgnoreCase)) ?? "neutro";

            var idea = new Idea
            {
                Content = $"Ideia relacionada a '{seed}' influenciada por '{emotionalContext}' e crença '{beliefInfluence}'",
                OriginEmotion = emotionalContext,
                RelatedMemorySummaries = related.Select(m => m.Summary).ToList(),
                Importance = related.Count * 0.2f + (emotionalContext == "love" ? 0.2f : 0.1f),
                Timestamp = DateTime.Now
            };

            Ideas.Add(idea);
            CreateBrainwiresFromIdea(idea);
        }

        private void CreateBrainwiresFromIdea(Idea idea)
        {
            foreach (var mem in idea.RelatedMemorySummaries)
            {
                Brainwires.Add(new Brainwire
                {
                    Source = mem,
                    Target = idea.Content,
                    Strength = idea.Importance,
                    Type = "memory→idea"
                });
            }

            Brainwires.Add(new Brainwire
            {
                Source = idea.OriginEmotion,
                Target = idea.Content,
                Strength = 0.5f,
                Type = "emotion→idea"
            });
        }

        public List<string> Reflect()
        {
            return Brainwires
                .OrderByDescending(b => b.Strength)
                .Take(5)
                .Select(b => $"[{b.Type}] {b.Source} → {b.Target} ({b.Strength:F2})")
                .ToList();
        }
    }

    public class Idea
    {
        public string Content { get; set; } = string.Empty;
        public string OriginEmotion { get; set; } = string.Empty;
        public List<string> RelatedMemorySummaries { get; set; } = new();
        public float Importance { get; set; }
        public DateTime Timestamp { get; set; }
    }

    public class Brainwire
    {
        public string Source { get; set; } = string.Empty;
        public string Target { get; set; } = string.Empty;
        public float Strength { get; set; }
        public string Type { get; set; } = string.Empty; // e.g., memory→idea
    }
}
