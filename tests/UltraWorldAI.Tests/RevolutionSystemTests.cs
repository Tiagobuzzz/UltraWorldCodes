using UltraWorldAI.Politics;
using Xunit;

public class RevolutionSystemTests
{
    [Fact]
    public void StartRevolutionAddsRevolt()
    {
        RevolutionSystem.Revolts.Clear();
        RevolutionSystem.StartRevolution("Reino", "Lider", "Causa");
        Assert.Single(RevolutionSystem.Revolts);
        Assert.Equal("Reino", RevolutionSystem.Revolts[0].Kingdom);
    }
}
