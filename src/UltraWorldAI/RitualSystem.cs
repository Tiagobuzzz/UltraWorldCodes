using System.Collections.Generic;

namespace UltraWorldAI
{
    public class RitualGesture
    {
        public string Name { get; set; } = string.Empty;
        public bool IsSacred { get; set; }
    }

    public class RitualSystem
    {
        public List<RitualGesture> KnownGestures { get; } = new();
    }
}
