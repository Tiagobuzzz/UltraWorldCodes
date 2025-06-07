using UltraWorldAI.Tradition;
using Xunit;

public class GenerationalSecretTraditionSystemTests
{
    [Fact]
    public void RecordSecretStoresSecret()
    {
        GenerationalSecretTraditionSystem.Secrets.Clear();
        GenerationalSecretTraditionSystem.RecordSecret("Ordem", "segredo", "Heroi");
        Assert.Single(GenerationalSecretTraditionSystem.Secrets);
    }

    [Fact]
    public void RevealReturnsSecretForDestinedOne()
    {
        GenerationalSecretTraditionSystem.Secrets.Clear();
        GenerationalSecretTraditionSystem.RecordSecret("Ordem", "segredo", "Heroi");
        GenerationalSecretTraditionSystem.AdvanceYears(5);
        var secret = GenerationalSecretTraditionSystem.Reveal("Ordem", "Heroi");
        Assert.Equal("segredo", secret);
    }
}
