using System.Collections.Generic;
using System.Linq;

namespace UltraWorldAI.Civilization
{
    /// <summary>
    /// Tracks reputation scores for cultures allowing ranked queries.
    /// </summary>
    public class CultureReputationSystem
    {
        public Dictionary<string, float> ReputationScores { get; } = new();

        /// <summary>
        /// Adjusts reputation for a given culture name.
        /// </summary>
        public void AdjustReputation(string culture, float delta)
        {
            ReputationScores[culture] = ReputationScores.GetValueOrDefault(culture) + delta;
        }

        /// <summary>
        /// Returns cultures ordered by reputation score descending.
        /// </summary>
        public List<string> GetRanking()
        {
            return ReputationScores
                .OrderByDescending(kv => kv.Value)
                .Select(kv => kv.Key)
                .ToList();
        }
    }
}
