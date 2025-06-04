using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text.Json;

namespace UltraWorldAI
{
    public class PersonalitySystem
    {
        public Dictionary<string, float> Traits { get; private set; } = new Dictionary<string, float>();

        public PersonalitySystem()
        {
            Traits.Add("Abertura", 0.7f);
            Traits.Add("Conscienciosidade", 0.6f);
            Traits.Add("Extroversão", 0.5f);
            Traits.Add("Amabilidade", 0.8f);
            Traits.Add("Neuroticismo", 0.3f);
        }

        public float GetTrait(string traitName)
        {
            return Traits.TryGetValue(traitName, out float value) ? value : 0.5f;
        }

        public void SetTrait(string traitName, float value)
        {
            Traits[traitName] = Math.Clamp(value, AIConfig.TraitMin, AIConfig.TraitMax);
        }
    }
}
