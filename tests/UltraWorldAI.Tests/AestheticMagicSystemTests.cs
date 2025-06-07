using UltraWorldAI.Module15;
using Xunit;

public class AestheticMagicSystemTests
{
    [Fact]
    public void CreateSpellRegistersSpell()
    {
        AestheticMagicSystem.Spells.Clear();
        AestheticMagicSystem.CreateSpell("Ana", "Dança", "Curar", 1f);
        Assert.Contains(AestheticMagicSystem.Spells, s => s.Artist == "Ana" && s.ArtForm == "Dança");
    }
}
