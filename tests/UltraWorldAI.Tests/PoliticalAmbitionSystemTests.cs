using UltraWorldAI.Politics;
using Xunit;

public class PoliticalAmbitionSystemTests
{
    [Fact]
    public void RegisterAmbitionAddsProfile()
    {
        PoliticalAmbitionSystem.Profiles.Clear();
        PoliticalAmbitionSystem.RegisterAmbition("Aeron", "Cavaleiro", "Duque");
        Assert.Single(PoliticalAmbitionSystem.Profiles);
    }
}
