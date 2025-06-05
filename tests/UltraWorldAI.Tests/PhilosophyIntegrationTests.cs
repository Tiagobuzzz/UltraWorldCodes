using UltraWorldAI.Philosophy;
using Xunit;

public class PhilosophyIntegrationTests
{
    [Fact]
    public void InterpretActionRespectsPhilosophy()
    {
        PhilosophySeed.AllPhilosophies.Clear();
        var p = PhilosophySeed.CreatePhilosophy("A", "A verdade exige sacrifício");
        PhilosophyIntegration.AssignPhilosophy("id1", p);
        var response = PhilosophyIntegration.InterpretAction("id1", "mentira detectada");
        Assert.Contains("recusa a mentir", response);
    }
}
