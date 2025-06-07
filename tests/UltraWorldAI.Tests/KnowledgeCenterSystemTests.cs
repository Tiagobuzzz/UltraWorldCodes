using System.Collections.Generic;
using UltraWorldAI.Knowledge;
using Xunit;

public class KnowledgeCenterSystemTests
{
    [Fact]
    public void CreateCenterStoresCenter()
    {
        KnowledgeCenterSystem.Centers.Clear();
        KnowledgeCenterSystem.CreateCenter("Arcanis", "Universidade", "Mist\u00e9rio", new List<string> { "Thalor" });
        Assert.Single(KnowledgeCenterSystem.Centers);
    }
}
