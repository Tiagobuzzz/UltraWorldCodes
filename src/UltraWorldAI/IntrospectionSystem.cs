using System;
using System.Collections.Generic;
using System.Linq;

namespace UltraWorldAI
{
    /// <summary>
    /// Provides basic self-reflection capabilities to the Mind.
    /// </summary>
    public class IntrospectionSystem
    {
        public List<string> RecentInsights { get; } = new();

        public void Reflect(Mind brain)
        {
            var dominantEmotion = brain.Emotions.GetDominantEmotion();
            var dominantVoice = brain.Subvoices.GetDominantVoice().Name;
            var currentGoal = brain.Goals.ActiveGoals
                .OrderByDescending(g => g.Urgency)
                .FirstOrDefault();

            string insight = $"Percebo que estou sentindo muita {dominantEmotion} " +
                             $"e que minha voz dominante é {dominantVoice}.";

            if (currentGoal != null)
                insight += $" Meu foco atual é: {currentGoal.Description}.";

            if (brain.Conflict.HasActiveContradictions())
                insight += " Há um conflito interno em andamento.";

            if (brain.Stress.CurrentStressLevel > 0.7f)
                insight += " Estou sob estresse significativo.";

            AddInsight(insight);
        }

        private void AddInsight(string insight)
        {
            RecentInsights.Add($"{DateTime.Now}: {insight}");
            if (RecentInsights.Count > 20)
                RecentInsights.RemoveAt(0);
        }

        public string GetLastInsight()
        {
            return RecentInsights.LastOrDefault() ?? "Sem introspecção recente.";
        }
    }
}
