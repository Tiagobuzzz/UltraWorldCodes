using UltraWorldAI.Relationships;
using Xunit;

public class UnconsciousDesireSystemTests
{
    [Fact]
    public void CreateBondAddsHiddenBond()
    {
        UnconsciousDesireSystem.HiddenBonds.Clear();
        UnconsciousDesireSystem.CreateBond("Kael", "Raela", "Desejo inconsciente", 0.75f, false);

        Assert.Contains(UnconsciousDesireSystem.HiddenBonds,
            b => b.Subject == "Kael" && b.Target == "Raela" && !b.Aware);
    }
}
