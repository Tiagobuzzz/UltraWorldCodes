using System.Collections.Generic;
using UltraWorldAI.Knowledge;
using Xunit;

public class ForbiddenKnowledgeNetworkTests
{
    [Fact]
    public void CreateNetworkStoresNetwork()
    {
        ForbiddenKnowledgeNetwork.Networks.Clear();
        ForbiddenKnowledgeNetwork.CreateNetwork(
            "Veu",
            new List<string>(),
            new List<string>(),
            "Codigo");
        Assert.Single(ForbiddenKnowledgeNetwork.Networks);
    }

    [Fact]
    public void InfluencePoliticsAddsAlliance()
    {
        ForbiddenKnowledgeNetwork.Networks.Clear();
        ForbiddenKnowledgeNetwork.CreateNetwork(
            "Veu",
            new List<string>(),
            new List<string>(),
            "Codigo");
        ForbiddenKnowledgeNetwork.InfluencePolitics("Veu", "Reino");
        Assert.Contains("Reino", ForbiddenKnowledgeNetwork.Networks[0].PoliticalAlliances);
    }
}

