using System;
using System.Collections.Generic;

namespace UltraWorldAI
{
    public class BeliefSystem
    {
        public Dictionary<string, float> Beliefs { get; private set; } = new Dictionary<string, float>();

        public BeliefSystem()
        {
            Beliefs.Add("Paz", 0.9f);
            Beliefs.Add("Justiça", 0.8f);
            Beliefs.Add("Comunidade", 0.7f);
            Beliefs.Add("Conhecimento é poder", 0.75f);
            Beliefs.Add("Autoconfiança é essencial", 0.6f);
        }

        public void UpdateBelief(string belief, float change)
        {
            if (Beliefs.ContainsKey(belief))
            {
                Beliefs[belief] = Math.Clamp(Beliefs[belief] + change, 0f, 1f);
            }
            else
            {
                Beliefs.Add(belief, Math.Clamp(change, 0f, 1f));
            }
        }
    }
}
