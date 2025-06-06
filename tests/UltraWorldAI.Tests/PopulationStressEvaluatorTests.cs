using System.Collections.Generic;
using UltraWorldAI;
using UltraWorldAI.Politics;
using Xunit;

public class PopulationStressEvaluatorTests
{
    [Fact]
    public void HighPopulationStressTriggersRevolt()
    {
        var gov = GovernmentFactory.CreateGovernment("City", GovernmentType.Republica, AuthorityBase.Voto, "Leader", "Centro");
        var people = new List<Person> { new("A"), new("B") };
        foreach (var p in people)
            p.Mind.Stress.AddStress(1f);

        var result = PopulationStressEvaluator.CheckForUprising(gov, people, "Novo");
        Assert.NotNull(result);
        Assert.Equal("Novo", gov.CurrentLeader);
    }
}
