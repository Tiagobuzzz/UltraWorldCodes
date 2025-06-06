using UltraWorldAI;
using Xunit;

public class PhotographicMemorySystemTests
{
    [Fact]
    public void DoesNotForgetMemories()
    {
        var mem = new PhotographicMemorySystem();
        for (int i = 0; i < AISettings.MaxMemories * 2; i++)
            mem.AddMemory($"m{i}");
        Assert.Equal(AISettings.MaxMemories * 2, mem.Memories.Count);
        var before = mem.Memories[0].Intensity;
        mem.UpdateMemoryDecay();
        Assert.Equal(before, mem.Memories[0].Intensity);
    }
}
