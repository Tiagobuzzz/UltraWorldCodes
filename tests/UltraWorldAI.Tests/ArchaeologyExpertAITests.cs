using UltraWorldAI.World.Archaeology;
using Xunit;

public class ArchaeologyExpertAITests
{
    [Fact]
    public void AddKnowledgeStoresDescription()
    {
        ArchaeologyExpertAI.AddKnowledge("vase", "ancient");
        Assert.Equal("ancient", ArchaeologyExpertAI.Describe("vase"));
    }
}
