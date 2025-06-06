using System.Collections.Generic;
using UltraWorldAI;
using UltraWorldAI.Politics;
using Xunit;

public class CivilUnrestTests
{
    [Fact]
    public void HighStressTriggersCivilUnrest()
    {
        var gov = GovernmentFactory.CreateGovernment("Utopia", GovernmentType.Republica, AuthorityBase.Voto, "Lider", "Centro");
        var people = new List<Person> { new("A"), new("B") };
        foreach (var p in people)
            p.Mind.Stress.AddStress(1f);
        var result = RevoltSystem.TriggerCivilUnrest(gov, people, "Rebelde");
        Assert.NotNull(result);
        Assert.Equal("Rebelde", gov.CurrentLeader);
    }
}
