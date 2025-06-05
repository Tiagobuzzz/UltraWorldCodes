using System;
using System.Collections.Generic;
using System.Linq;

namespace UltraWorldAI
{
    /// <summary>
    /// Maintains a log of internal thoughts and reflections.
    /// </summary>
    public class InternalNarrativeSystem
    {
        public List<string> NarrativeLog { get; } = new();
        public string? LastReflection { get; private set; }
        public float IntrospectionLevel { get; set; } = 0.5f;

        private static readonly Random _random = new();

        public void GenerateReflection(Mind mind)
        {
            if (_random.NextDouble() > IntrospectionLevel)
                return;

            var dominantEmotion = mind.Emotions.GetDominantEmotion();
            var topGoal = mind.Goals.ActiveGoals
                .OrderByDescending(g => g.Urgency)
                .FirstOrDefault();

            var dominantVoice = mind.Subvoices.GetDominantVoice();

            string thought = $"[{dominantVoice.Name}]: ";

            if (topGoal != null)
            {
                thought += $"Estou focado em '{topGoal.Description}' e sinto {dominantEmotion}.";
            }
            else
            {
                thought += $"Sinto {dominantEmotion}, mas estou sem direção.";
            }

            if (mind.Conflict.HasActiveContradictions())
            {
                int level = mind.Conflict.ActiveContradictions.Count;
                thought += $" Conflitos internos presentes ({level}).";
            }

            NarrativeLog.Add(thought);
            LastReflection = thought;

            if (NarrativeLog.Count > 50)
                NarrativeLog.RemoveAt(0);
        }

        public void AddSubjectiveThought(string message)
        {
            NarrativeLog.Add("[Reflexão]: " + message);
            if (NarrativeLog.Count > 50)
                NarrativeLog.RemoveAt(0);
        }

        public string GetLastNarrativeSummary()
        {
            return LastReflection ?? "Silêncio interno...";
        }

        public void InteractWithSubvoices(SubpersonalitySystem subvoices)
        {
            var ordered = subvoices.Subpersonalities
                .OrderByDescending(s => s.CurrentInfluence)
                .Take(3)
                .Select(s => $"[{s.Name} diz]: {GenerateOpinion(s)}");

            NarrativeLog.AddRange(ordered);

            if (NarrativeLog.Count > 50)
                NarrativeLog.RemoveRange(0, NarrativeLog.Count - 50);
        }

        private static string GenerateOpinion(Subpersona s)
        {
            return s.Name switch
            {
                "Guerreiro" => "Devemos agir logo.",
                "Filósofo" => "Será que estamos no caminho certo?",
                "Ferido" => "Isso tudo me lembra algo doloroso...",
                "Amante" => "E se tentarmos acolher em vez de atacar?",
                "Explorador" => "Talvez haja algo novo à frente.",
                _ => "Não sei o que pensar."
            };
        }
    }
}
