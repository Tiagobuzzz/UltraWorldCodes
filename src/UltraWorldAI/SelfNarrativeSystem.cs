using System;
using System.Collections.Generic;
using System.Linq;

namespace UltraWorldAI
{
    // Maintains core narratives and defends them when identity is threatened
    public class SelfNarrativeSystem
    {
        private readonly Person _person;
        public Dictionary<string, float> CoreNarratives { get; private set; } = new Dictionary<string, float>();
        private readonly Random _rand = new Random();

        public SelfNarrativeSystem(Person person)
        {
            _person = person;
            CoreNarratives["sou justo"] = 0.8f;
            CoreNarratives["busco paz"] = 0.8f;
        }

        public void AddOrUpdateNarrative(string text, float strength)
        {
            CoreNarratives[text] = Math.Clamp(strength, 0f, 1f);
        }

        public string DefendNarrative(string narrative)
        {
            var options = new List<string>
            {
                $"Isso não muda o fato de que {narrative}.",
                $"A situação foi atípica, mas continuo acreditando que {narrative}.",
                $"As circunstâncias me forçaram, porém {narrative} permanece verdadeiro."
            };
            _person.Mind.Stress.ReduceStress(AIConfig.StressReductionPerDefense);
            return options[_rand.Next(options.Count)];
        }

        public void UpdateNarrative()
        {
            foreach (var key in CoreNarratives.Keys.ToList())
            {
                CoreNarratives[key] = Math.Clamp(CoreNarratives[key] + 0.001f, 0f, 1f);
            }
        }
    }
}
