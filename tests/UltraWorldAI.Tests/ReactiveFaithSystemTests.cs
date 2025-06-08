using UltraWorldAI.Religion;
using Xunit;

public class ReactiveFaithSystemTests
{
    [Fact]
    public void RecordingMiraclesIncreasesFanaticism()
    {
        ReactiveFaithSystem.RecordMiracle("Mara");
        ReactiveFaithSystem.RecordMiracle("Mara");

        var level = ReactiveFaithSystem.GetFanaticism("Mara");

        Assert.True(level > 0.6f);
    }
}
