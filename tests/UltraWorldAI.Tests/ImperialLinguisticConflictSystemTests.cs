using UltraWorldAI.Language;
using Xunit;

public class ImperialLinguisticConflictSystemTests
{
    [Fact]
    public void DeclareConflictAddsEntry()
    {
        ImperialLinguisticConflictSystem.Conflicts.Clear();
        ImperialLinguisticConflictSystem.DeclareConflict("R1", "R2", "Lang", "dominio");
        Assert.Single(ImperialLinguisticConflictSystem.Conflicts);
    }
}
