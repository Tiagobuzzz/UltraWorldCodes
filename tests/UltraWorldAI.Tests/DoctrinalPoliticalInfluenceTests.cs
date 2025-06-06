using UltraWorldAI.Doctrine;
using Xunit;

public class DoctrinalPoliticalInfluenceTests
{
    [Fact]
    public void RegisterInfluenceStoresEvent()
    {
        DoctrinalPoliticalInfluence.Events.Clear();
        DoctrinalPoliticalInfluence.RegisterInfluence(
            "Biblioteca do Sol", "Dogma", "Aurora",
            "Lucro sobre alimentos é pecado", 1270);

        Assert.Single(DoctrinalPoliticalInfluence.Events);
        var ev = DoctrinalPoliticalInfluence.Events[0];
        Assert.Equal("Aurora", ev.AffectedEntity);
        Assert.Contains(ev, DoctrinalPoliticalInfluence.GetInfluencesFor("Aurora"));
    }
}

