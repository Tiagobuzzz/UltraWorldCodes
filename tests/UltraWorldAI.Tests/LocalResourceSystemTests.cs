using UltraWorldAI.Economy;
using Xunit;

public class LocalResourceSystemTests
{
    [Fact]
    public void AddResourceStoresNode()
    {
        LocalResourceSystem.Resources.Clear();
        LocalResourceSystem.AddResource("Vale", "Ferro", 100, true);
        Assert.Single(LocalResourceSystem.Resources);
        var node = LocalResourceSystem.Resources[0];
        Assert.Equal("Vale", node.Region);
        Assert.Equal(100, node.Quantity);
    }

    [Fact]
    public void DepleteResourceReducesQuantity()
    {
        LocalResourceSystem.Resources.Clear();
        LocalResourceSystem.AddResource("Montanha", "Ouro", 50, false);
        LocalResourceSystem.DepleteResource("Montanha", "Ouro", 10);
        Assert.Equal(40, LocalResourceSystem.Resources[0].Quantity);
    }
}
