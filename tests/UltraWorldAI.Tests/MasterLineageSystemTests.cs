using UltraWorldAI.Knowledge;
using Xunit;

public class MasterLineageSystemTests
{
    [Fact]
    public void AddLinkStoresLineage()
    {
        MasterLineageSystem.Links.Clear();
        MasterLineageSystem.AddLink("Kael", "Raela", "Alquimia", false, 1450);
        Assert.Single(MasterLineageSystem.Links);
    }
}
