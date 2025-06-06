using UltraWorldAI.Visualization;
using UltraWorldAI.World;
using Xunit;

public class ExternalAppExporterTests
{
    [Fact]
    public void ExportSettlementDataIncludesName()
    {
        var settlement = new Settlement { Name = "TestTown", Region = "R1", Population = 10 };
        var json = ExternalAppExporter.ExportSettlementData(settlement);
        Assert.Contains("TestTown", json);
    }
}
