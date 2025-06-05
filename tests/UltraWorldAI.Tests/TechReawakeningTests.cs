using System.Collections.Generic;
using UltraWorldAI.Discovery;
using Xunit;

public class TechReawakeningTests
{
    [Fact]
    public void ReinterpretReturnsNewTech()
    {
        TechCreator.TechPool.Clear();
        var original = TechCreator.CreateTech("IA", new List<string> { "som" });
        var revived = TechReawakening.Reinterpret("Pensador", original.Name);

        Assert.NotNull(revived);
        Assert.StartsWith(original.Name, revived!.Name);
    }
}
