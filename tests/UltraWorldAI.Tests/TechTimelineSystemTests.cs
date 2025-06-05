using UltraWorldAI.History;
using Xunit;

public class TechTimelineSystemTests
{
    [Fact]
    public void CreateEraAddsEra()
    {
        TechTimelineSystem.Eras.Clear();
        TechTimelineSystem.CreateEra("fogo", "tribal");
        Assert.Single(TechTimelineSystem.Eras);
        string desc = TechTimelineSystem.DescribeAll();
        Assert.Contains("Era de fogo", desc);
    }
}
