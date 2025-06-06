using UltraWorldAI.Environmental;
using Xunit;

public class GreenPolicySystemTests
{
    [Fact]
    public void EnactAddsPolicy()
    {
        GreenPolicySystem.Policies.Clear();
        GreenPolicySystem.Enact("Region", "Recycle");
        Assert.Single(GreenPolicySystem.Policies);
    }
}
