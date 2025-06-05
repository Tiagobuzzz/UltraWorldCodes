using System;
using System.Collections.Generic;
using System.Linq;

namespace UltraWorldAI
{
    public class SimulationSystem
    {
        public List<InternalScenario> ImaginedScenarios { get; private set; }
        public string LifeNarrative { get; private set; }

        private static readonly Random _random = new Random();

        public SimulationSystem()
        {
            ImaginedScenarios = new List<InternalScenario>();
            LifeNarrative = "Início de uma jornada desconhecida...";
        }

        public void Simulate(EmotionSystem emotions, GoalSystem goals, MemorySystem memory)
        {
            ImaginedScenarios.Clear();

            var primaryGoal = goals.ActiveGoals.OrderByDescending(g => g.Urgency).FirstOrDefault();
            if (primaryGoal == null) return;

            var imaginedOutcome = GenerateOutcome(primaryGoal, emotions);
            ImaginedScenarios.Add(imaginedOutcome);

            UpdateLifeNarrative(imaginedOutcome);
        }

        private InternalScenario GenerateOutcome(Goal goal, EmotionSystem emotions)
        {
            var emotion = emotions.GetDominantEmotion();
            var outcome = new InternalScenario
            {
                Goal = goal.Description,
                ImaginedEmotion = emotion,
                Outcome = SimulateConsequence(goal.Description, emotion),
                Confidence = _random.NextDouble() * 0.8 + 0.2
            };

            return outcome;
        }

        private string SimulateConsequence(string goal, string emotion)
        {
            if (emotion == "fear" && goal.Contains("confrontar"))
                return "Você se machuca e gera conflito social.";
            if (emotion == "love" && goal.Contains("cuidar"))
                return "Você fortalece vínculos e ganha confiança.";
            if (emotion == "anger")
                return "Você toma decisões impulsivas e causa problemas.";
            if (goal.Contains("explorar"))
                return "Você encontra algo inesperado.";
            return "Você age, mas o resultado é incerto.";
        }

        private void UpdateLifeNarrative(InternalScenario scenario)
        {
            var entry = $"Pensou em '{scenario.Goal}' com sentimento de '{scenario.ImaginedEmotion}' e visualizou: '{scenario.Outcome}'";
            LifeNarrative += "\n→ " + entry;

            if (LifeNarrative.Length > 500)
                LifeNarrative = LifeNarrative[^500..];
        }

        public List<string> GetRecentSimulations()
        {
            return ImaginedScenarios.Select(s =>
                $"Meta: {s.Goal}, Emoção: {s.ImaginedEmotion}, Consequência: {s.Outcome}, Confiança: {s.Confidence:F2}")
                .ToList();
        }

        public string GetLifeNarrative() => LifeNarrative;
    }

    public class InternalScenario
    {
        public string Goal { get; set; } = string.Empty;
        public string ImaginedEmotion { get; set; } = string.Empty;
        public string Outcome { get; set; } = string.Empty;
        public double Confidence { get; set; }
    }
}
