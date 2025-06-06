using System.Collections.Generic;
using UltraWorldAI;
using UltraWorldAI.Politics;
using Xunit;

public class SuccessionConflictSystemTests
{
    [Fact]
    public void RevoltOrAssassinationWhenLegitimacyLow()
    {
        var gov = GovernmentFactory.CreateGovernment("Testland", GovernmentType.Monarquia, AuthorityBase.Sangue, "Rei", "Capital");
        var old = new Person("Rei", "Dynastia");
        var candidate = new Person("Rival", "Dynastia");
        var list = new List<Person> { old, candidate };

        LegitimacySystem.Legitimacy.Clear();
        LegitimacySystem.Register("Rival", LegitimacySource.Sangue, 0.1f);

        var result = SuccessionConflictSystem.ResolveSuccession(gov, list, "Dynastia");
        Assert.NotEmpty(result);
        Assert.NotEqual("Rei", gov.CurrentLeader);
    }
}
