using UltraWorldAI.Politics;
using Xunit;

public class HistoricalManipulationSystemTests
{
    [Fact]
    public void ForgeTreatyAddsAction()
    {
        HistoricalManipulationSystem.Actions.Clear();
        HistoricalManipulationSystem.ForgeTreaty("Pacto", "Lorde", "ganhar territorio");
        Assert.Single(HistoricalManipulationSystem.Actions);
    }
}
