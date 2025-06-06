using UltraWorldAI.Discovery;
using Xunit;

public class LostTechnologyRegistryTests
{
    [Fact]
    public void RediscoverRemovesFromList()
    {
        LostTechnologyRegistry.Lost.Clear();
        LostTechnologyRegistry.RegisterLost("magia", 100);
        var found = LostTechnologyRegistry.Rediscover("magia");
        Assert.True(found);
        Assert.Empty(LostTechnologyRegistry.Lost);
    }
}
