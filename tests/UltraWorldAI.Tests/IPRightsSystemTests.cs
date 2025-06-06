using UltraWorldAI.Law;
using Xunit;

public class IPRightsSystemTests
{
    [Fact]
    public void RegisterWorkStoresOwner()
    {
        IPRightsSystem.RegisterWork("invento", "Alice");
        Assert.True(IPRightsSystem.IsRegistered("invento"));
        Assert.Equal("Alice", IPRightsSystem.GetOwner("invento"));
    }
}
