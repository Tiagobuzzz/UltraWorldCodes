using System.Collections.Generic;

namespace UltraWorldAI.Discovery
{
    public class ConceptualTech
    {
        public string Name { get; set; } = string.Empty;
        public string CreatedBy { get; set; } = string.Empty;
        public List<string> CombinedConcepts { get; set; } = new();
        public string HypotheticalFunction { get; set; } = string.Empty;
        public bool IsFunctional { get; set; }
        public string Complexity { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
    }
}
