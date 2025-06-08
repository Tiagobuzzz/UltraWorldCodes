using UltraWorldAI.Religion;
using Xunit;

public class FaithReactivitySystemTests
{
    [Fact]
    public void RegisterMiracleIncreasesFanaticism()
    {
        FaithReactivitySystem.FanaticismByCulture.Clear();
        FaithReactivitySystem.RegisterMiracle("Arkhim");
        FaithReactivitySystem.RegisterMiracle("Arkhim");

        Assert.True(FaithReactivitySystem.FanaticismByCulture["Arkhim"] >= 0.5f);
    }
}
