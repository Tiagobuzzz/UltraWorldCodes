using UltraWorldAI.Module15;
using Xunit;

public class ArtAsWeaponSystemTests
{
    [Fact]
    public void DeployArtRegistersCampaign()
    {
        ArtAsWeaponSystem.Campaigns.Clear();
        ArtAsWeaponSystem.DeployArt("Traidor", "Resistência", "Peça", "Império", "Despertar");
        Assert.Contains(ArtAsWeaponSystem.Campaigns, c => c.Title == "Traidor" && c.Faction == "Resistência" && c.Medium == "Peça" && c.Target == "Império" && c.Purpose == "Despertar");
    }
}
