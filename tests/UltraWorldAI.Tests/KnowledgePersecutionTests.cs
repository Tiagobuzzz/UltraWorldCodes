using UltraWorldAI.Discovery;
using Xunit;

public class KnowledgePersecutionTests
{
    [Fact]
    public void ForbidTechRegistersInBlacklist()
    {
        KnowledgePersecution.Blacklist.Clear();
        KnowledgePersecution.ForbidTech("Tec-1", "Rei", "heresia");

        Assert.True(KnowledgePersecution.IsForbidden("Tec-1"));
        Assert.Single(KnowledgePersecution.Blacklist);
    }
}
