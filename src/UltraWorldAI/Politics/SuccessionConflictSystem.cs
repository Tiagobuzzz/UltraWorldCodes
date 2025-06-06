using System.Collections.Generic;
using System.Linq;

namespace UltraWorldAI.Politics;

public static class SuccessionConflictSystem
{
    public static string ResolveSuccession(PowerStructure gov, List<Person> candidates, string bloodline)
    {
        var successor = SuccessionSystem.DetermineSuccessor(gov, candidates, bloodline);
        var legitimacy = LegitimacySystem.GetOverall(successor);

        if (legitimacy < 0.5f)
        {
            if (Random.Shared.NextDouble() < 0.5)
            {
                return RevoltSystem.TriggerRevolt(gov, successor);
            }

            var oldLeader = gov.CurrentLeader;
            var target = candidates.FirstOrDefault(c => c.Name == oldLeader);
            target?.Die();
            SuccessionSystem.ApplySuccessor(gov, successor);
            return $"⚔️ {successor} assassinou {oldLeader} e tomou o trono.";
        }

        SuccessionSystem.ApplySuccessor(gov, successor);
        return $"📜 {successor} foi coroado sem oposição.";
    }
}
