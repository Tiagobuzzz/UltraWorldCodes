using UltraWorldAI.Traditions;
using Xunit;

public class OralTraditionRecorderTests
{
    [Fact]
    public void RecordAddsStory()
    {
        var rec = new OralTraditionRecorder();
        rec.Record("Ancião", "História antiga");
        Assert.Single(rec.Stories);
        Assert.Contains("Ancião", rec.NarrateAll());
    }
}
