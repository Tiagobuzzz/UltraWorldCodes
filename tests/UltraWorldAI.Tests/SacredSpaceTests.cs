using UltraWorldAI;
using UltraWorldAI.Territory;
using Xunit;

public class SacredSpaceTests
{
    [Fact]
    public void SanctifyRegionAddsToSet()
    {
        SacredSpace.SanctifyRegion("Monte");
        Assert.True(SacredSpace.IsSacred("Monte"));
    }

    [Fact]
    public void InfluenceMindGeneratesIdeaAndReducesStress()
    {
        var person = new Person("Devoto");
        person.Mind.Stress.AddStress(0.5f);
        SacredSpace.SanctifyRegion("Templo");

        SacredSpace.InfluenceMind(person.Mind, "Templo");

        Assert.Contains(person.Mind.IdeaEngine.GeneratedIdeas,
            i => i.Title.Contains("Lugar Sagrado: Templo"));
        Assert.True(person.Mind.Stress.CurrentStressLevel < 0.5f);
    }
}
