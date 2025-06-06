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

    [Theory]
    [InlineData("fear", "pavor")]
    [InlineData("sorrow", "tristeza")]
    public void RetrieveMemoriesByEmotionFiltersCorrectly(string emotion, string expected)
    {
        var memSys = new MemorySystem();
        memSys.AddMemory("tristeza", 0.6f, -0.5f, null, "self", "sorrow");
        memSys.AddMemory("alegria", 0.7f, 0.8f, null, "self", "happiness");
        memSys.AddMemory("pavor", 0.9f, -0.9f, null, "self", "fear");

        var results = memSys.RetrieveMemoriesByEmotion(emotion, 2);

        Assert.Single(results);
        Assert.Equal(expected, results[0].Summary);
    }

    [Fact]
    public void GetMostIntenseMemoryReturnsHighestIntensity()
    {
        var memSys = new MemorySystem();
        memSys.AddMemory("fraco", 0.1f);
        memSys.AddMemory("forte", 0.9f);

        var top = memSys.GetMostIntenseMemory();

        Assert.NotNull(top);
        Assert.Equal("forte", top!.Summary);
    }

    [Fact]
    public void RemoveMemoriesByKeywordPurgesMatchingEntries()
    {
        var memSys = new MemorySystem();
        memSys.AddMemory("alpha beta", 0.5f, 0f, new() { "alpha" });
        memSys.AddMemory("gamma", 0.5f, 0f, new() { "gamma" });

        memSys.RemoveMemoriesByKeyword("alpha");

        Assert.DoesNotContain(memSys.Memories, m => m.Summary.Contains("alpha"));
        Assert.Single(memSys.Memories);
    }
}
