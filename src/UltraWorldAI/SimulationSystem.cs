using System;
using System.Collections.Generic;
using System.Linq;

namespace UltraWorldAI
{
    public class SimulationSystem
    {
        public List<InternalScenario> ImaginedScenarios { get; private set; }
        public string LifeNarrative { get; private set; }
        public bool DebugMode { get; set; }
        public Interface.IExternalAIService? ExternalService { get; set; }
        public string ExternalEndpoint { get; set; } = string.Empty;

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

            if (DebugMode)
                Logger.Log($"Simulating goal '{primaryGoal.Description}'", LogLevel.Debug);

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

            if (ExternalService != null && !string.IsNullOrEmpty(ExternalEndpoint))
            {
                var enhanced = ExternalService.QueryAsync(ExternalEndpoint, outcome.Outcome)
                    .GetAwaiter().GetResult();
                if (!string.IsNullOrEmpty(enhanced))
                    outcome.Outcome = enhanced;
            }

            if (DebugMode)
                Logger.Log($"Generated scenario: {outcome.Outcome}", LogLevel.Debug);

            return outcome;
        }

        private string SimulateConsequence(string goal, string emotion)
        {
            return (emotion, goal) switch
            {
                ("fear", var g) when g.Contains("confrontar")
                    => "Você se machuca e gera conflito social.",
                ("love", var g) when g.Contains("cuidar")
                    => "Você fortalece vínculos e ganha confiança.",
                ("anger", _) => "Você toma decisões impulsivas e causa problemas.",
                (_, var g) when g.Contains("explorar")
                    => "Você encontra algo inesperado.",
                _ => "Você age, mas o resultado é incerto."
            };
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
