using System.Collections.Generic;
using UltraWorldAI.Economy;
using Xunit;

public class EconomicUniversitySystemTests
{
    [Fact]
    public void CreateInstitutionStoresData()
    {
        EconomicUniversitySystem.Institutions.Clear();
        EconomicUniversitySystem.CreateInstitution(
            "Biblioteca do Sol",
            "Aurora",
            "Kael",
            new List<string> { "Valor Interno" },
            new List<string> { "Puristas", "Realistas" });

        Assert.Single(EconomicUniversitySystem.Institutions);
        var inst = EconomicUniversitySystem.Institutions[0];
        Assert.Equal("Biblioteca do Sol", inst.Name);
        Assert.Contains("Puristas", inst.InternalFactions);
    }

    [Fact]
    public void ModifyInfluenceClampsBetweenZeroAndHundred()
    {
        EconomicUniversitySystem.Institutions.Clear();
        EconomicUniversitySystem.CreateInstitution(
            "Templo da Moeda",
            "Umbra",
            "Zor'mak",
            new List<string>(),
            new List<string>());

        EconomicUniversitySystem.ModifyInfluence("Templo da Moeda", 60);
        EconomicUniversitySystem.ModifyInfluence("Templo da Moeda", 100);

        var inst = EconomicUniversitySystem.Institutions[0];
        Assert.Equal(100, inst.CulturalInfluence);
    }
}
