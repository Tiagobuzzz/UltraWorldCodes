using System;
using System.Collections.Generic;
using System.Linq;

namespace UltraWorldAI
{
    public class BeliefNode
    {
        public string Statement { get; set; } = string.Empty;
        public float Conviction { get; set; }
        public string Origin { get; set; } = string.Empty;
        public string AssociatedEmotion { get; set; } = string.Empty;
        public bool IsCoreBelief => Conviction > 0.8f;
    }

    public class BeliefArchitecture
    {
        public List<BeliefNode> Beliefs { get; } = new();

        public void AddBelief(string statement, float conviction, string origin, string emotion)
        {
            var existing = Beliefs.FirstOrDefault(b => b.Statement == statement);
            if (existing != null)
            {
                existing.Conviction = Math.Clamp(existing.Conviction + conviction * 0.2f, 0f, 1f);
            }
            else
            {
                Beliefs.Add(new BeliefNode
                {
                    Statement = statement,
                    Conviction = conviction,
                    Origin = origin,
                    AssociatedEmotion = emotion
                });
            }
        }

        public List<(BeliefNode, BeliefNode)> DetectContradictions()
        {
            var contradictions = new List<(BeliefNode, BeliefNode)>();

            foreach (var a in Beliefs)
            {
                foreach (var b in Beliefs)
                {
                    if (a != b && AreContradictory(a.Statement, b.Statement))
                    {
                        contradictions.Add((a, b));
                    }
                }
            }

            return contradictions;
        }

        public void ResolveContradictions(ConflictSystem conflict, EmotionSystem emotions)
        {
            var contradictions = DetectContradictions();

            foreach (var (a, b) in contradictions)
            {
                float tension = Math.Abs(a.Conviction - b.Conviction) + emotions.GetEmotion(a.AssociatedEmotion) * 0.3f;

                if (tension > 0.6f)
                {
                    conflict.TriggerContradiction("crença", $"{a.Statement} ↔ {b.Statement}");

                    if (a.Conviction < b.Conviction)
                    {
                        a.Conviction = Math.Max(0f, a.Conviction - 0.1f);
                    }
                    else
                    {
                        b.Conviction = Math.Max(0f, b.Conviction - 0.1f);
                    }
                }
            }

            Beliefs.RemoveAll(b => b.Conviction < 0.1f);
        }

        private static bool AreContradictory(string a, string b)
        {
            return a.Contains("sempre", StringComparison.OrdinalIgnoreCase) && b.Contains("nunca", StringComparison.OrdinalIgnoreCase) ||
                   a.Contains("nunca", StringComparison.OrdinalIgnoreCase) && b.Contains("sempre", StringComparison.OrdinalIgnoreCase) ||
                   a.Contains("liberdade", StringComparison.OrdinalIgnoreCase) && b.Contains("controle", StringComparison.OrdinalIgnoreCase) ||
                   a.Contains("controle", StringComparison.OrdinalIgnoreCase) && b.Contains("liberdade", StringComparison.OrdinalIgnoreCase) ||
                   a.Contains("violência", StringComparison.OrdinalIgnoreCase) && b.Contains("paz", StringComparison.OrdinalIgnoreCase) ||
                   a.Contains("paz", StringComparison.OrdinalIgnoreCase) && b.Contains("violência", StringComparison.OrdinalIgnoreCase) ||
                   a.Contains("caos", StringComparison.OrdinalIgnoreCase) && b.Contains("ordem", StringComparison.OrdinalIgnoreCase) ||
                   a.Contains("ordem", StringComparison.OrdinalIgnoreCase) && b.Contains("caos", StringComparison.OrdinalIgnoreCase) ||
                   a.Contains("fé", StringComparison.OrdinalIgnoreCase) && b.Contains("dúvida", StringComparison.OrdinalIgnoreCase) ||
                   a.Contains("dúvida", StringComparison.OrdinalIgnoreCase) && b.Contains("fé", StringComparison.OrdinalIgnoreCase) ||
                   (a.Contains("Deus", StringComparison.OrdinalIgnoreCase) && b.Contains("ateísmo", StringComparison.OrdinalIgnoreCase)) ||
                   (a.Contains("ateísmo", StringComparison.OrdinalIgnoreCase) && b.Contains("Deus", StringComparison.OrdinalIgnoreCase));
        }
    }
}
