using System;
using System.Collections.Generic;
using System.Linq;

namespace UltraWorldAI
{
    public class Idea
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public float EmotionalCharge { get; set; }
        public float SymbolicPower { get; set; }
        public List<string> AssociatedMemories { get; set; } = new();
        public List<string> RelatedIdeas { get; set; } = new();
        public bool IsExpressed { get; set; }
        public float InfluenceOnWorld { get; set; }
    }

    public class Brainwire
    {
        public string IdeaA { get; set; } = string.Empty;
        public string IdeaB { get; set; } = string.Empty;
        public float Strength { get; set; }
        public float ConflictLevel { get; set; }
    }

    public class IdeaEngine
    {
        public List<Idea> GeneratedIdeas { get; } = new();
        public List<Brainwire> BrainConnections { get; } = new();
        private static readonly Random _random = new();

        public void GenerateIdea(string trigger, List<string> relatedMemories, EmotionSystem emotions)
        {
            var dominantEmotion = emotions.GetDominantEmotion();
            var idea = new Idea
            {
                Title = trigger,
                Description = $"Reflexao sobre {trigger} impulsionada por {dominantEmotion}",
                EmotionalCharge = emotions.GetEmotion(dominantEmotion),
                SymbolicPower = 0.3f + relatedMemories.Count * 0.1f,
                AssociatedMemories = relatedMemories
            };
            GeneratedIdeas.Add(idea);
        }

        public void LinkIdeas(string ideaA, string ideaB)
        {
            var wire = new Brainwire
            {
                IdeaA = ideaA,
                IdeaB = ideaB,
                Strength = 0.5f,
                ConflictLevel = 0f
            };
            BrainConnections.Add(wire);
        }

        public void ExpressIdea(string ideaTitle, Mind mind)
        {
            var idea = GeneratedIdeas.FirstOrDefault(i => i.Title == ideaTitle);
            if (idea == null || idea.IsExpressed) return;

            idea.IsExpressed = true;
            idea.InfluenceOnWorld += (float)_random.NextDouble();
            mind.Memory.AddMemory($"Expressou a ideia '{idea.Title}'", 0.4f, idea.EmotionalCharge, new() { "Ideia" }, "ideia");
        }
    }
}
