using System.Linq;
using UltraWorldAI.Magic;
using Xunit;

public class MagicSystemsTests
{
    [Fact]
    public void RegisterSourceAddsToList()
    {
        MagicSourceSystem.RegisterSource("Nexo", "Espiritual", "Tumor", false);
        Assert.Contains(MagicSourceSystem.Sources, s => s.Name == "Nexo");
    }

    [Fact]
    public void AddLawStoresMagicLaw()
    {
        MagicRulesAndRisksSystem.AddLaw("Chamada", "Lua cheia", "Memoria", "Corrupcao");
        Assert.Contains(MagicRulesAndRisksSystem.Laws, l => l.Name == "Chamada");
    }

    [Fact]
    public void RegisterSchoolAddsSchool()
    {
        MagicCultureSystem.RegisterSchool("Olho", "Althar", "Controle", false);
        Assert.Contains(MagicCultureSystem.Schools, s => s.Name == "Olho");
    }
}
