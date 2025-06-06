using UltraWorldAI.Politics;
using Xunit;

public class PowerIntrigueSystemTests
{
    [Fact]
    public void ExecutePlotAddsEntry()
    {
        PowerIntrigueSystem.Plots.Clear();
        PowerIntrigueSystem.ExecutePlot("Selena", "Reino de Kael", "Golpe");
        Assert.Single(PowerIntrigueSystem.Plots);
    }
}
