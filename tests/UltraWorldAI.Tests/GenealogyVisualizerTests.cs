using UltraWorldAI.Civilization;
using UltraWorldAI.Visualization;
using Xunit;

public class GenealogyVisualizerTests
{
    [Fact]
    public void RenderReturnsTree()
    {
        var root = new GenealogyNode { Name = "Root" };
        root.Descendants.Add(new GenealogyNode { Name = "Child" });
        var output = GenealogyVisualizer.Render(root);
        Assert.Contains("Root", output);
        Assert.Contains("Child", output);
    }
}
