using System.Collections.Generic;
using UltraWorldAI.Politics.War;

namespace UltraWorldAI.Politics;

public static class DiplomaticReactionSystem
{
    public static void ApplyBetrayalReactions(IEnumerable<Person> persons)
    {
        foreach (var treaty in WarDiplomacySystem.Treaties)
        {
            if (!treaty.Broken) continue;
            foreach (var person in persons)
            {
                if (person.Name == treaty.BetweenA)
                    person.Mind.Social.ApplyPunishment(treaty.BetweenB, 0.2f);
                if (person.Name == treaty.BetweenB)
                    person.Mind.Social.ApplyPunishment(treaty.BetweenA, 0.2f);
            }
        }
    }
}
