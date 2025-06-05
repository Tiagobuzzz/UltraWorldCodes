using System.Collections.Generic;
using UltraWorldAI.Territory;

namespace UltraWorldAI
{
    public class DivineBeing
    {
        public string Name { get; set; } = string.Empty;
        public string Appearance { get; set; } = string.Empty;
        public List<string> Domains { get; } = new();
        public string Agenda { get; set; } = string.Empty;
        public Dictionary<string, float> Traits { get; } = new();

        public void Inspire(Mind mind)
        {
            mind.Beliefs.UpdateBelief($"fé em {Name}", 0.2f);
            mind.Memory.AddMemory($"Sentiu a presença de {Name}", 0.6f, 0.9f, new() { "religião" }, "divino");
        }

        public void BlessRegion(string regionName)
        {
            SacredSpace.SanctifyRegion(regionName);
        }
    }
}
