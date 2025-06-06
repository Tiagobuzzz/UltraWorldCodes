using UltraWorldAI.Politics;
using Xunit;

public class VassalageSystemTests
{
    [Fact]
    public void DeclareVassalAddsRelation()
    {
        VassalageSystem.Relations.Clear();
        VassalageSystem.DeclareVassal("Kael", "Selena", "Bosques", "Fe");
        Assert.Single(VassalageSystem.Relations);
    }

    [Fact]
    public void BreakOathUpdatesLoyalty()
    {
        VassalageSystem.Relations.Clear();
        VassalageSystem.DeclareVassal("Kael", "Selena", "Bosques", "Fe");
        VassalageSystem.BreakOath("Selena");
        Assert.False(VassalageSystem.Relations[0].IsLoyal);
    }
}
