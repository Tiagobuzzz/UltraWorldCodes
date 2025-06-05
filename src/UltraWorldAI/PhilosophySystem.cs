using System;
using System.Collections.Generic;
using System.Linq;

namespace UltraWorldAI
{
    public class PhilosophySystem
    {
        public string? CorePhilosophy { get; private set; }
        public List<string> Doctrines { get; } = new();
        public float ConsistencyScore { get; private set; } = 1f;

        public void Update(Mind brain)
        {
            var dominantEmotion = brain.Emotions.GetDominantEmotion();
            var dominantVoice = brain.Subvoices.GetDominantVoice().Name;
            var insight = brain.Intuition.GetCoreBeliefs().FirstOrDefault();

            if (CorePhilosophy == null && insight != null)
            {
                CorePhilosophy = $"A verdade surge através de {insight.EmotionBasis}";
                Doctrines.Add($"Seguir a voz do {dominantVoice}");
                Doctrines.Add($"Evitar {GetOppositeEmotion(insight.EmotionBasis)}");
            }

            CheckConsistency(brain);
        }

        private void CheckConsistency(Mind brain)
        {
            var currentGoal = brain.Goals.ActiveGoals.FirstOrDefault();
            if (currentGoal != null &&
                Doctrines.Any(d =>
                    currentGoal.Description.Contains(GetOppositeConcept(d), StringComparison.OrdinalIgnoreCase)))
            {
                ConsistencyScore = Math.Max(0f, ConsistencyScore - 0.1f);
                brain.Conflict.TriggerContradiction("filosofia", currentGoal.Description);
            }
            else
            {
                ConsistencyScore = Math.Min(1f, ConsistencyScore + 0.01f);
            }
        }

        private static string GetOppositeEmotion(string emotion)
        {
            return emotion switch
            {
                "fear" => "coragem",
                "anger" => "paz",
                "sorrow" => "alegria",
                "happiness" => "dor",
                "love" => "frieza",
                _ => "dúvida"
            };
        }

        private static string GetOppositeConcept(string doctrine)
        {
            var check = doctrine.ToLowerInvariant();
            if (check.Contains("buscar")) return "evitar";
            if (check.Contains("seguir")) return "questionar";
            if (check.Contains("lutar")) return "fugir";
            if (check.Contains("honrar")) return "esquecer";
            return string.Empty;
        }
    }
}
