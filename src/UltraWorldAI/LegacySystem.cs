using System;
using System.Collections.Generic;
using System.Linq;

namespace UltraWorldAI
{
    public class LegacySystem
    {
        public Dictionary<string, float> TransmissibleTraits { get; private set; } = new();
        public List<string> MemeticInfluences { get; private set; } = new();
        public List<Memory> LegacyMemories { get; private set; } = new();
        public Biology.Genome? Genome { get; private set; }

        public void DefineLegacyFromMind(Mind mind)
        {
            TransmissibleTraits = mind.Personality.Traits
                .ToDictionary(kv => kv.Key, kv => kv.Value);

            MemeticInfluences = mind.Beliefs.Beliefs
                .Where(kv => kv.Key.Contains("Visão", StringComparison.OrdinalIgnoreCase) ||
                             kv.Key.Contains("Visao", StringComparison.OrdinalIgnoreCase) ||
                             kv.Key.Contains("doutrina", StringComparison.OrdinalIgnoreCase) ||
                             kv.Key.Contains("tradição", StringComparison.OrdinalIgnoreCase))
                .Select(kv => kv.Key)
                .ToList();

            LegacyMemories = mind.Memory.Memories
                .OrderByDescending(m => Math.Abs(m.EmotionalCharge))
                .Take(5)
                .ToList();

            Genome = mind.PersonReference.Genome;
        }

        public void ApplyLegacyToNewPerson(Person newPerson)
        {
            foreach (var trait in TransmissibleTraits)
            {
                newPerson.Mind.Personality.AdjustTrait(trait.Key, trait.Value * 0.5f);
            }

            foreach (var belief in MemeticInfluences)
            {
                newPerson.Mind.Beliefs.UpdateBelief(belief, 0.3f);
            }

            foreach (var mem in LegacyMemories)
            {
                newPerson.Mind.Memory.AddMemory(
                    $"Lembrança herdada: {mem.Summary}",
                    mem.Intensity * 0.3f,
                    mem.EmotionalCharge * 0.3f,
                    new List<string>(mem.Keywords) { "herança" },
                    "legacy");
            }

            if (Genome != null)
            {
                newPerson.Genome = Biology.GeneticReproduction.CrossGenomes(Genome, newPerson.Genome);
            }
        }
    }
}

