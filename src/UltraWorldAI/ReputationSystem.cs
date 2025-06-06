using System.Collections.Generic;

namespace UltraWorldAI
{
    public class ReputationSystem
    {
        public List<string> Tags { get; } = new();

        public float GetReputation(string tag)
        {
            return Tags.Contains(tag) ? 1f : 0f;
        }
    }
}
