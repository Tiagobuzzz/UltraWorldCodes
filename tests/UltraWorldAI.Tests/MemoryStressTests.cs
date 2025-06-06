using UltraWorldAI;
using Xunit;

public class MemoryStressTests
{
    [Fact]
    public void AddingManyMemoriesMaintainsLimit()
    {
        var mem = new MemorySystem();
        for (int i = 0; i < AISettings.MaxMemories * 2; i++)
            mem.AddMemory($"m{i}");
        Assert.Equal(AISettings.MaxMemories, mem.Memories.Count);
    }
}
