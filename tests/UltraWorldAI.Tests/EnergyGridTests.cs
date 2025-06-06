using UltraWorldAI.Energy;
using Xunit;

public class EnergyGridTests
{
    [Fact]
    public void BalanceReturnsNetEnergy()
    {
        EnergyGrid.AddSource("solar", 100);
        EnergyGrid.AddConsumer("base", 80);
        var net = EnergyGrid.Balance();
        Assert.InRange(net, 19, 21);
    }
}
