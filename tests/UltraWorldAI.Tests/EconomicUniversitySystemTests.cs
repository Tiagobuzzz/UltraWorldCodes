using UltraWorldAI.Education;
using System.Collections.Generic;
using Xunit;

public class EconomicUniversitySystemTests
{
    [Fact]
    public void CreateAndModifyInstitution()
    {
        EconomicUniversitySystem.Institutions.Clear();
        EconomicUniversitySystem.CreateInstitution("Biblioteca", "Aurora", "Kael", new List<string>(), new List<string>());
        EconomicUniversitySystem.ModifyInfluence("Biblioteca", 20, propagate: false);
        var inst = Assert.Single(EconomicUniversitySystem.Institutions);
        Assert.Equal(70, inst.CulturalInfluence);
    }
}
