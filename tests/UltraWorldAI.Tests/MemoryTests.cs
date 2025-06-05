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

    [Fact]
    public void RetrieveMemoriesOrdersByWeight()
    {
        var memSys = new MemorySystem();
        memSys.AddMemory("neutro", 0.3f, 0.1f, new() { "teste" });
        memSys.AddMemory("emocional", 0.2f, 0.9f, new() { "teste" });

        var result = memSys.RetrieveMemories("teste", 2);

        Assert.Equal("emocional", result[0].Summary);
    }
}
