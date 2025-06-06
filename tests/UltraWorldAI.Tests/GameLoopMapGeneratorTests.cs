using UltraWorldAI.Game;
using Xunit;

public class GameLoopMapGeneratorTests
{
    private class CountingGenerator : IMapGenerator
    {
        public int Calls { get; private set; }
        public GameMap Generate(int width, int height, int seed = 0)
        {
            Calls++;
            return new GameMap(width, height);
        }
    }

    [Fact]
    public void ConstructorUsesProvidedGenerator()
    {
        var gen = new CountingGenerator();
        var loop = new GameLoop(2, 2, false, false, null, gen);
        Assert.Equal(1, gen.Calls);
    }
}
