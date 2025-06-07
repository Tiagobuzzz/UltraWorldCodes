using System.Collections.Generic;
using UltraWorldAI.Module15;
using Xunit;

public class StyleConflictSystemTests
{
    [Fact]
    public void AddSchoolAddsFaction()
    {
        StyleConflictSystem.Factions.Clear();
        StyleConflictSystem.AddSchool("Caos", "Simbolo", new List<string> { "Ordem" }, "Ruptura");
        Assert.Contains(StyleConflictSystem.Factions, f => f.SchoolName == "Caos" && f.CoreSymbol == "Simbolo" && f.Opposes.Contains("Ordem") && f.ArtisticPhilosophy == "Ruptura");
    }
}
