using UltraWorldAI.Economy;
using Xunit;

public class EconomicIdeologyConflictSystemTests
{
    [Fact]
    public void DeclareConflictAddsEntry()
    {
        EconomicIdeologyConflictSystem.Conflicts.Clear();
        EconomicIdeologyConflictSystem.DeclareConflict("Escola A", "Escola B", "Censura", 1300);
        Assert.Single(EconomicIdeologyConflictSystem.Conflicts);
        var c = EconomicIdeologyConflictSystem.Conflicts[0];
        Assert.Equal("Escola A", c.SchoolA);
        Assert.Equal("Escola B", c.SchoolB);
        Assert.Equal("Censura", c.ConflictType);
        Assert.Equal(1300, c.Year);
    }

    [Fact]
    public void DuplicateConflictIsIgnored()
    {
        EconomicIdeologyConflictSystem.Conflicts.Clear();
        EconomicIdeologyConflictSystem.DeclareConflict("A", "B", "Guerra", 1250);
        EconomicIdeologyConflictSystem.DeclareConflict("A", "B", "Guerra", 1250);
        Assert.Single(EconomicIdeologyConflictSystem.Conflicts);
    }
}
