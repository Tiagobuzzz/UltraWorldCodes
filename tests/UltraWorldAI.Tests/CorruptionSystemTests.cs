using UltraWorldAI.Politics;
using Xunit;
using System.Linq;

public class CorruptionSystemTests
{
    [Fact]
    public void InvestigationMarksCase()
    {
        CorruptionSystem.Cases.Clear();
        CorruptionSystem.ReportCase("Prefeito", "Suborno");
        CorruptionSystem.InvestigateAll();
        Assert.True(CorruptionSystem.Cases.Any(c => c.Description == "Suborno" && c.Investigated));
    }
}
