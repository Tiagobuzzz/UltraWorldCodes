using UltraWorldAI.Doctrine;
using Xunit;

public class PhilosopherLegacySystemTests
{
    [Fact]
    public void RegisterPhilosopherStoresData()
    {
        PhilosopherLegacySystem.Figures.Clear();
        PhilosopherLegacySystem.RegisterPhilosopher(
            "Kael",
            "Aurora",
            "Frio",
            "Exilado",
            "Somente o vazio pesa menos que o ouro");

        Assert.Single(PhilosopherLegacySystem.Figures);
        var p = PhilosopherLegacySystem.Figures[0];
        Assert.Equal("Kael", p.Name);

        PhilosopherLegacySystem.AddSchool("Kael", "Troca Justa");
        PhilosopherLegacySystem.AddDoctrine("Kael", "Valor Interno");

        Assert.Contains("Troca Justa", p.FoundedSchools);
        Assert.Contains("Valor Interno", p.DoctrinesInfluenced);
    }
}
