using UltraWorldAI.DivineWorld;
using Xunit;

public class DivineWillSystemTests
{
    [Fact]
    public void InterveneAddsAction()
    {
        DivineWillSystem.Interventions.Clear();
        DivineWillSystem.Intervene("Cidade", "Milagre", "Chuva de estrelas");
        Assert.Single(DivineWillSystem.Interventions);
        Assert.Equal("Cidade", DivineWillSystem.Interventions[0].Target);
    }

    [Fact]
    public void SetPersonalityChangesState()
    {
        DivineWillSystem.SetPersonality(DivinePersonality.Chaotic);
        Assert.Equal(DivinePersonality.Chaotic, DivineWillSystem.Personality);
    }
}

