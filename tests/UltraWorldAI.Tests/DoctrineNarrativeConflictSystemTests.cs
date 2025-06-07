using UltraWorldAI.Doctrine;
using Xunit;

public class DoctrineNarrativeConflictSystemTests
{
    [Fact]
    public void EscalateChangesRegimeWhenSupportHigh()
    {
        DoctrineNarrativeConflictSystem.Conflicts.Clear();
        DoctrineNarrativeConflictSystem.AddConflict("Reino", "Oficial", "Popular", 60);
        DoctrineNarrativeConflictSystem.Escalate("Reino", 15);

        Assert.True(DoctrineNarrativeConflictSystem.Conflicts[0].RegimeChanged);
    }
}
