using System;

namespace UltraWorldAI.Game;

public static class MapGenerator
{
    public static GameMap Generate(int width, int height, int seed = 0)
    {
        if (seed != 0)
            Random.Shared.Next();
        var map = new GameMap(width, height);
        return map;
    }
}
