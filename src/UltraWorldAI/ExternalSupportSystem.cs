using System;
using System.Collections.Generic;
using System.Linq;

namespace UltraWorldAI
{
    public class ExternalSupportSystem
    {
        public float SocialPressure { get; private set; }
        public float ReputationWeight { get; private set; }
        public float RitualObligation { get; private set; }

        public void EvaluateInfluences(Person self)
        {
            CalculateSocialPressure(self.Mind.Social.Relationships);
            CalculateReputationInfluence(self.Mind.Reputation);
            CalculateRitualDemands(self.Mind.Rituals);
        }

        private void CalculateSocialPressure(List<SocialRelationship> relationships)
        {
            float totalAffinity = relationships.Sum(r => r.Affinity);
            SocialPressure = relationships.Count > 0
                ? totalAffinity / relationships.Count
                : 0f;
        }

        private void CalculateReputationInfluence(ReputationSystem reputation)
        {
            ReputationWeight = reputation.Tags.Contains("herói") ? 0.8f :
                               reputation.Tags.Contains("traidor") ? -0.8f :
                               reputation.Tags.Count * 0.1f;
        }

        private void CalculateRitualDemands(RitualSystem rituals)
        {
            RitualObligation = rituals.KnownGestures.Count(g => g.IsSacred) * 0.2f;
            RitualObligation = Math.Min(1f, RitualObligation);
        }

        public float GetTotalExternalInfluence()
        {
            return (SocialPressure * 0.4f) + (ReputationWeight * 0.4f) + (RitualObligation * 0.2f);
        }

        public string DescribeExternalForces()
        {
            return $"Pressão Social: {SocialPressure:F2}, Reputação: {ReputationWeight:F2}, Rituais: {RitualObligation:F2}";
        }
    }
}
