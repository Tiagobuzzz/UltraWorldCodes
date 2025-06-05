using System;
using System.Linq;

namespace UltraWorldAI
{
    public class CognitiveFeedbackSystem
    {
        public float SelfAwarenessLevel { get; private set; } = 0.1f;

        public void EvaluateTrajectory(Mind brain)
        {
            var dominant = brain.Subvoices.GetDominantVoice();
            if (dominant.Name == "Ferido" && brain.Emotions.GetEmotion("sorrow") > 0.7f)
            {
                SelfAwarenessLevel += 0.01f;
                brain.Memory.AddMemory("Reconheceu padrão de dor e retraimento", 0.2f, -0.1f, null, "FeedbackInterno");
            }

            var repeatedGoal = brain.Goals.ActiveGoals
                .GroupBy(g => g.Description)
                .FirstOrDefault(g => g.Count() > 2);

            if (repeatedGoal != null)
            {
                SelfAwarenessLevel += 0.015f;
                brain.Beliefs.UpdateBelief("autoquestionamento", 0.1f);
            }

            if (brain.Emotions.GetEmotion("anger") > 0.8f && !brain.Social.Relationships.Any())
            {
                SelfAwarenessLevel += 0.02f;
                brain.Memory.AddMemory("Suspeita de raiva interna sem gatilho externo", 0.3f, -0.2f, null, "Autocrítica");
            }

            SelfAwarenessLevel = Math.Clamp(SelfAwarenessLevel, 0f, 1f);
        }

        public string GetSelfInsight()
        {
            if (SelfAwarenessLevel < 0.2f) return "Autopercepção limitada.";
            if (SelfAwarenessLevel < 0.5f) return "Começando a entender padrões próprios.";
            if (SelfAwarenessLevel < 0.8f) return "Capaz de autoanálise e autocrítica.";
            return "Consciência reflexiva avançada.";
        }
    }
}
