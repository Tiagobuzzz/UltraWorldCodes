using System.Collections.Generic;

namespace UltraWorldAI.Game;

public sealed class DefaultPathfinder : IPathfinder
{
    public List<(int x, int y)> FindPath(GameMap map, int startX, int startY, int goalX, int goalY)
        => Pathfinder.FindPath(map, startX, startY, goalX, goalY);
}
