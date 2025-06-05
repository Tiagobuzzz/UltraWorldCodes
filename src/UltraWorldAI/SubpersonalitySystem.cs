using System;
using System.Collections.Generic;
using System.Linq;

namespace UltraWorldAI
{
    public class Subpersona
    {
        public string Name { get; set; } = string.Empty;
        public float CurrentInfluence { get; set; }
    }

    public class SubpersonalitySystem
    {
        public List<Subpersona> Subpersonalities { get; } = new();
        private static readonly Random _random = new();

        public SubpersonalitySystem()
        {
            Subpersonalities.Add(new Subpersona { Name = "Guerreiro", CurrentInfluence = 0.5f });
            Subpersonalities.Add(new Subpersona { Name = "Filósofo", CurrentInfluence = 0.5f });
            Subpersonalities.Add(new Subpersona { Name = "Ferido", CurrentInfluence = 0.5f });
            Subpersonalities.Add(new Subpersona { Name = "Amante", CurrentInfluence = 0.5f });
            Subpersonalities.Add(new Subpersona { Name = "Explorador", CurrentInfluence = 0.5f });
        }

        public Subpersona GetDominantVoice()
        {
            return Subpersonalities
                .OrderByDescending(s => s.CurrentInfluence)
                .First();
        }

        public void UpdateInfluences()
        {
            foreach (var sub in Subpersonalities)
            {
                float change = ((float)_random.NextDouble() - 0.5f) * 0.1f;
                sub.CurrentInfluence = Math.Clamp(sub.CurrentInfluence + change, 0f, 1f);
            }
        }
    }
}
