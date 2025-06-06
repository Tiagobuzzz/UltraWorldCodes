using System;
using System.Collections.Generic;

namespace UltraWorldAI
{
    public class PersonalitySystem
    {
        public Dictionary<string, float> Traits { get; private set; } = new Dictionary<string, float>();

        private static readonly Random _rand = new();

        public PersonalitySystem()
        {
            Traits.Add("Abertura", RandomInitial());
            Traits.Add("Conscienciosidade", RandomInitial());
            Traits.Add("Extroversão", RandomInitial());
            Traits.Add("Amabilidade", RandomInitial());
            Traits.Add("Neuroticismo", RandomInitial());
        }

        private static float RandomInitial()
        {
            return (float)(_rand.NextDouble() * 0.2 + 0.4);
        }

        public float GetTrait(string traitName)
        {
            return Traits.TryGetValue(traitName, out float value) ? value : 0.5f;
        }

        public void SetTrait(string traitName, float value)
        {
            Traits[traitName] = Math.Clamp(value, AIConfig.TraitMin, AIConfig.TraitMax);
        }

        public void AdjustTrait(string traitName, float delta)
        {
            var current = GetTrait(traitName);
            SetTrait(traitName, current + delta);
        }
    }
}
