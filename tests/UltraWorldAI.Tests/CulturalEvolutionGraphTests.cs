using UltraWorldAI.Visualization;
using Xunit;

public class CulturalEvolutionGraphTests
{
    [Fact]
    public void AddPointStoresData()
    {
        var graph = new CulturalEvolutionGraph();
        graph.AddPoint(100, 1.5);
        Assert.Single(graph.GetPoints());
    }
}
