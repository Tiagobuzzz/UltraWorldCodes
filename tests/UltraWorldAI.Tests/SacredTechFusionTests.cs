using UltraWorldAI.Fusion;
using Xunit;

public class SacredTechFusionTests
{
    [Fact]
    public void FuseCreatesFusion()
    {
        SacredTechFusion.Fusions.Clear();
        var fusion = SacredTechFusion.Fuse("TecP", "Magia", "Culto", "paz");

        Assert.Single(SacredTechFusion.Fusions);
        Assert.Equal("TecP", fusion.TechName);
    }
}
