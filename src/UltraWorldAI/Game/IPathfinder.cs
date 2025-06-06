using System.Collections.Generic;

namespace UltraWorldAI.Game;

public interface IPathfinder
{
    List<(int x, int y)> FindPath(GameMap map, int startX, int startY, int goalX, int goalY);
}
