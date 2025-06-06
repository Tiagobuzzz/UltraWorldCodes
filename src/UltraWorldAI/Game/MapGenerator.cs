using System;

namespace UltraWorldAI.Game;

public class MapGenerator : IMapGenerator
{
    public GameMap Generate(int width, int height, int seed = 0)
    {
        if (seed != 0)
            Random.Shared.Next(seed);
        var map = new GameMap(width, height);
        var rand = new Random(seed);
        for (int x = 0; x < width; x++)
        for (int y = 0; y < height; y++)
        {
            if (rand.NextDouble() < 0.1)
                map.SetObstacle(x, y, true);
        }
        return map;
    }
}
