using System;
using System.Collections.Generic;

namespace UltraWorldAI.Thoughts
{
    public class HistoricalIdentity
    {
        public List<string> LifeEvents { get; } = new();
        public string MythicTitle { get; private set; } = "Anônimo";
        public string LegacyPhrase { get; private set; } = "Nada será lembrado.";
        public int FamePoints { get; private set; }

        public void RegisterEvent(string symbolicEvent)
        {
            LifeEvents.Add($"{DateTime.Now:yyyy-MM-dd} - {symbolicEvent}");
            AddFame(1);
            UpdateLegacy();
        }

        public void AddFame(int points)
        {
            FamePoints += points;
        }

        private void UpdateLegacy()
        {
            if (LifeEvents.Count > 3)
            {
                MythicTitle = $"Aquele que {ExtractEssence()}";
                LegacyPhrase = $"Seu nome ecoa por \"{LifeEvents.Count}\" memórias.";
            }
        }

        private string ExtractEssence()
        {
            if (LifeEvents.Exists(e => e.Contains("sacrifício"))) return "se sacrificou por outros";
            if (LifeEvents.Exists(e => e.Contains("construiu"))) return "ergueu algo eterno";
            if (LifeEvents.Exists(e => e.Contains("quebrou um tabu"))) return "desafiou os símbolos";
            return "viveu intensamente";
        }
    }
}
