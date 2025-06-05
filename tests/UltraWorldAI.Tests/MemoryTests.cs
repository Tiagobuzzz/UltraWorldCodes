using UltraWorldAI;
using Xunit;

public class MemoryTests
{
    [Fact]
    public void AddMemoryStoresEntry()
    {
        var memSys = new MemorySystem();
        memSys.AddMemory("evento", 0.5f);
        Assert.Single(memSys.Memories);
    }
}
