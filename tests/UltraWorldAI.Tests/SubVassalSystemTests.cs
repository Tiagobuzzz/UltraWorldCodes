using UltraWorldAI.Politics;
using Xunit;

public class SubVassalSystemTests
{
    [Fact]
    public void RegisterSubVassalAddsNetworkEntry()
    {
        SubVassalSystem.Network.Clear();
        SubVassalSystem.RegisterSubVassal("Casa Grivia", "Casa Umbra", "Vale");
        Assert.Single(SubVassalSystem.Network);
    }

    [Fact]
    public void DeclareRebellionMarksRebellious()
    {
        SubVassalSystem.Network.Clear();
        SubVassalSystem.RegisterSubVassal("Casa Grivia", "Casa Umbra", "Vale");
        SubVassalSystem.DeclareRebellion("Casa Grivia");
        Assert.True(SubVassalSystem.Network[0].IsRebellious);
    }
}
