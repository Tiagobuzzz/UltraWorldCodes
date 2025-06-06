using UltraWorldAI.Politics;
using Xunit;

public class CouncilRegencySystemTests
{
    [Fact]
    public void AddCouncilMemberAddsEntry()
    {
        CouncilRegencySystem.Council.Clear();
        CouncilRegencySystem.AddCouncilMember("Selena", "Oráculo", true);
        Assert.Single(CouncilRegencySystem.Council);
    }

    [Fact]
    public void DeclareRegencyAddsEntry()
    {
        CouncilRegencySystem.Regencies.Clear();
        CouncilRegencySystem.DeclareRegency("Umbra", "Selena", "Lyria", false);
        Assert.Contains(CouncilRegencySystem.Regencies, r => r.Regent == "Selena" && r.Kingdom == "Umbra");
    }
}
