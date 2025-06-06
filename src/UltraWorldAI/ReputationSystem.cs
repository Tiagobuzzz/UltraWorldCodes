using System.Collections.Generic;

namespace UltraWorldAI
{
    public class ReputationSystem
    {
        private readonly Dictionary<string, float> _scores = new();

        public IReadOnlyDictionary<string, float> Scores => _scores;

        public void AdjustReputation(string tag, float delta)
        {
            _scores[tag] = _scores.GetValueOrDefault(tag) + delta;
        }

        public float GetReputation(string tag)
        {
            return _scores.GetValueOrDefault(tag);
        }
    }
}
