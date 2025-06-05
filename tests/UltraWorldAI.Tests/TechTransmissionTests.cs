using UltraWorldAI.Discovery;
using Xunit;

public class TechTransmissionTests
{
    [Fact]
    public void ShareTechAddsOwner()
    {
        TechTransmission.TechOwners.Clear();
        TechTransmission.ShareTech("Tec-X", "A", "B");

        Assert.Contains("B", TechTransmission.TechOwners["Tec-X"]);
    }

    [Fact]
    public void StealTechRegistersThief()
    {
        TechTransmission.TechOwners.Clear();
        TechTransmission.StealTech("Tec-Y", "Ladrao");

        Assert.Contains("Ladrao", TechTransmission.TechOwners["Tec-Y"]);
    }
}
