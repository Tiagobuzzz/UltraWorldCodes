using UltraWorldAI.Politics.War;
using UltraWorldAI.World;
using Xunit;

public class InternationalEspionageSystemTests
{
    [Fact]
    public void RunCalculatesRisk()
    {
        var origin = new Settlement { Name = "A", Population = 100 };
        var target = new Settlement { Name = "B", Population = 300 };
        var report = InternationalEspionageSystem.Run(origin, target, 0.5);
        Assert.InRange(report.Risk, 0, 1);
    }
}
