using UltraWorldAI.Knowledge;
using Xunit;

public class OralTransmissionSystemTests
{
    [Fact]
    public void TeachStoresEvent()
    {
        OralTransmissionSystem.History.Clear();
        OralTransmissionSystem.Teach("Kael", "Raela", "Po\u00e9tica lunar", 0.85f, "Ritual");
        Assert.Single(OralTransmissionSystem.History);
    }
}
