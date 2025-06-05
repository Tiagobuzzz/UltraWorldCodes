using UltraWorldAI.Conflict;
using Xunit;

public class TechCivilizationConflictTests
{
    [Fact]
    public void DeclareAddsWar()
    {
        TechCivilizationConflict.Wars.Clear();
        var war = TechCivilizationConflict.Declare("A", "B", "laser", "poder");
        Assert.Contains(war, TechCivilizationConflict.Wars);
    }

    [Fact]
    public void ResolveSetsOutcome()
    {
        var war = TechCivilizationConflict.Declare("A", "B", "laser", "poder");
        TechCivilizationConflict.Resolve(war);
        Assert.True(war.IsResolved);
        Assert.False(string.IsNullOrEmpty(war.Outcome));
    }
}
