namespace UltraWorldAI.Game;

public interface IMapGenerator
{
    GameMap Generate(int width, int height, int seed = 0);
}
