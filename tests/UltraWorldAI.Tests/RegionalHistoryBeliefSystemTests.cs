using UltraWorldAI;
using UltraWorldAI.History;
using Xunit;

public class RegionalHistoryBeliefSystemTests
{
    [Fact]
    public void TeachReturnsRegionalVersion()
    {
        var person = new Person("Historian");
        RegionalHistoryBeliefSystem.RegisterBirthPlace(person, "Norte");
        RegionalHistoryBeliefSystem.AddEvent("Batalha", "O rei venceu");
        RegionalHistoryBeliefSystem.AddRegionalVersion("Batalha", "Norte", "O povo rebelde triunfou");

        var result = RegionalHistoryBeliefSystem.Teach(person, "Batalha");
        Assert.Equal("O povo rebelde triunfou", result);
    }
}
