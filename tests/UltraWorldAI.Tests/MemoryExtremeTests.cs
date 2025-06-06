using UltraWorldAI;
using Xunit;

public class MemoryExtremeTests
{
    [Fact]
    public void AddMemoryRespectsMaxLimit()
    {
        var mem = new MemorySystem();
        for (int i = 0; i < AISettings.MaxMemories + 20; i++)
            mem.AddMemory($"e{i}");
        Assert.Equal(AISettings.MaxMemories, mem.Memories.Count);
    }
}
