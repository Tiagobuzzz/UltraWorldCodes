using UltraWorldAI.Relationships;
using Xunit;

public class DeepBondAndHeartbreakSystemTests
{
    [Fact]
    public void BreakBondMarksAsBroken()
    {
        DeepBondAndHeartbreakSystem.Bonds.Clear();
        DeepBondAndHeartbreakSystem.CreateBond("Kael", "Saren", "Promise", 90);
        DeepBondAndHeartbreakSystem.BreakBond("Kael", "Saren", "Betrayal");
        var bond = DeepBondAndHeartbreakSystem.Bonds[0];
        Assert.True(bond.Broken);
        Assert.Equal("Betrayal", bond.BreakReason);
    }
}
