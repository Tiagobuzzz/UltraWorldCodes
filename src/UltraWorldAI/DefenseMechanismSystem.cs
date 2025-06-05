using System;
using System.Collections.Generic;
using System.Linq;

namespace UltraWorldAI
{
    public class DefenseMechanismSystem
    {
        public List<string> ActiveDefenses { get; } = new();
        public Dictionary<string, float> DefenseScores { get; } = new();

        public void EvaluateDefenses(ConflictSystem conflict, EmotionSystem emotions, BeliefArchitecture beliefs)
        {
            ActiveDefenses.Clear();

            if (conflict.HasActiveContradictions())
            {
                if (emotions.GetEmotion("anger") > 0.5f)
                    ActivateDefense("projeção");

                if (emotions.GetEmotion("sorrow") > 0.6f)
                    ActivateDefense("negação");

                if (emotions.GetEmotion("fear") > 0.5f)
                    ActivateDefense("compensação");
            }

            if (beliefs.Beliefs.Any(b => b.Statement.Contains("sou fraco", StringComparison.OrdinalIgnoreCase) && b.Conviction > 0.6f) &&
                emotions.GetEmotion("anger") > 0.6f)
            {
                ActivateDefense("deslocamento");
            }

            if (emotions.GetEmotion("love") > 0.6f && emotions.GetEmotion("sorrow") > 0.5f)
                ActivateDefense("idealização");

            if (emotions.GetEmotion("fear") > 0.8f)
                ActivateDefense("anestesia emocional");
        }

        private void ActivateDefense(string type)
        {
            if (!ActiveDefenses.Contains(type))
                ActiveDefenses.Add(type);

            if (!DefenseScores.ContainsKey(type))
                DefenseScores[type] = 0.1f;
            else
                DefenseScores[type] = Math.Min(1f, DefenseScores[type] + 0.05f);
        }

        public float GetDefenseIntensity(string type)
        {
            return DefenseScores.TryGetValue(type, out var score) ? score : 0f;
        }

        public void Decay()
        {
            foreach (var key in DefenseScores.Keys.ToList())
                DefenseScores[key] *= 0.995f;
        }

        public bool IsEmotionBlocked(string emotion)
        {
            return ActiveDefenses.Contains("anestesia emocional") &&
                   (string.Equals(emotion, "sorrow", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(emotion, "love", StringComparison.OrdinalIgnoreCase));
        }
    }
}
