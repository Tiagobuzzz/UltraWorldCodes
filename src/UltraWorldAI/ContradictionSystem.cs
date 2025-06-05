using System;
using System.Collections.Generic;
using System.Linq;

namespace UltraWorldAI
{
    public class ContradictionSystem
    {
        public List<string> Contradictions { get; } = new();
        public List<string> SelfSabotageEvents { get; } = new();
        public float InnerTensionLevel { get; private set; }

        public void EvaluateContradictions(GoalSystem goals, EmotionSystem emotions, SubpersonalitySystem subvoices)
        {
            Contradictions.Clear();
            InnerTensionLevel = 0f;

            var goal = goals.ActiveGoals.OrderByDescending(g => g.Urgency).FirstOrDefault();
            var dominant = subvoices.GetDominantVoice();

            if (goal != null && dominant != null)
            {
                if (goal.Description.Contains("confrontar", StringComparison.OrdinalIgnoreCase)
                    && dominant.Name == "Filósofo")
                {
                    Contradictions.Add("Deseja confrontar, mas sente que deveria refletir.");
                    InnerTensionLevel += 0.4f;
                }

                if (goal.Description.Contains("amar", StringComparison.OrdinalIgnoreCase)
                    && dominant.Name == "Ferido")
                {
                    Contradictions.Add("Deseja conexão, mas o trauma impede proximidade.");
                    InnerTensionLevel += 0.6f;
                }
            }

            if (emotions.GetEmotion("love") > 0.6f && emotions.GetEmotion("fear") > 0.6f)
            {
                Contradictions.Add("Ama intensamente, mas teme profundamente.");
                InnerTensionLevel += 0.5f;
            }

            var topVoices = subvoices.Subpersonalities
                .OrderByDescending(v => v.CurrentInfluence)
                .Take(2)
                .ToList();
            if (topVoices.Count == 2 &&
                Math.Abs(topVoices[0].CurrentInfluence - topVoices[1].CurrentInfluence) < 0.1f)
            {
                Contradictions.Add("Duas vozes internas lutam pelo controle.");
                InnerTensionLevel += 0.3f;
            }

            InnerTensionLevel = Math.Min(1f, InnerTensionLevel);
        }

        public void TriggerSelfSabotage(Mind brain)
        {
            if (InnerTensionLevel > 0.6f)
            {
                const string action = "Desistiu de um objetivo importante.";
                SelfSabotageEvents.Add(action);
                brain.Goals.ActiveGoals.Clear();
                brain.Memory.AddMemory(action, 0.5f, -0.5f, new() { "Autossabotagem" }, "self");
            }
        }

        public string GetContradictionSummary()
        {
            return Contradictions.Any()
                ? $"⚠️ Contradições: {string.Join("; ", Contradictions)}"
                : "🟢 Estado psicológico estável.";
        }
    }
}
