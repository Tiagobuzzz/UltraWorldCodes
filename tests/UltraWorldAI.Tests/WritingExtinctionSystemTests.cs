using UltraWorldAI.Language;
using Xunit;

public class WritingExtinctionSystemTests
{
    [Fact]
    public void ForgetUntilZeroMarksExtinct()
    {
        WritingExtinctionSystem.Legacies.Clear();
        WritingExtinctionSystem.Remember("Runica");
        WritingExtinctionSystem.Forget("Runica");
        Assert.True(WritingExtinctionSystem.Legacies[0].IsExtinct);
    }

    [Fact]
    public void RestoreRevivesScript()
    {
        WritingExtinctionSystem.Legacies.Clear();
        WritingExtinctionSystem.Remember("Runica");
        WritingExtinctionSystem.Forget("Runica");
        WritingExtinctionSystem.Restore("Runica", 1);
        Assert.False(WritingExtinctionSystem.Legacies[0].IsExtinct);
    }
}
