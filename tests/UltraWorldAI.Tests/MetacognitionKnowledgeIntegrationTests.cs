using UltraWorldAI;
using UltraWorldAI.Discovery;
using Xunit;

public class MetacognitionKnowledgeIntegrationTests
{
    [Fact]
    public void ForbidTechUpdatesMetacognition()
    {
        var person = new Person("Elias");
        var meta = new MetacognitionSystem(person);
        KnowledgePersecution.Blacklist.Clear();

        KnowledgePersecution.ForbidTechWithMetacognition("TecX", "Alta Igreja", "perigoso", meta);

        Assert.Contains("TecX", meta.ForbiddenKnowledge);
        Assert.True(KnowledgePersecution.IsForbidden("TecX"));
    }
}
