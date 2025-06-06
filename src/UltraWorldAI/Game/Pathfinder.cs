using System.Collections.Generic;

namespace UltraWorldAI.Game;

public static class Pathfinder
{
    private static readonly (int x, int y)[] Directions =
    {
        (1,0), (-1,0), (0,1), (0,-1)
    };

    public static List<(int x, int y)> FindPath(GameMap map, int startX, int startY, int goalX, int goalY)
    {
        var queue = new Queue<(int x, int y)>();
        var cameFrom = new Dictionary<(int x, int y), (int x, int y)>();
        queue.Enqueue((startX, startY));
        cameFrom[(startX, startY)] = (startX, startY);

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            if (current == (goalX, goalY))
                break;

            foreach (var dir in Directions)
            {
                int nx = current.x + dir.x;
                int ny = current.y + dir.y;
                if (nx < 0 || ny < 0 || nx >= map.Width || ny >= map.Height)
                    continue;
                if (cameFrom.ContainsKey((nx, ny)))
                    continue;
                cameFrom[(nx, ny)] = current;
                queue.Enqueue((nx, ny));
            }
        }

        var path = new List<(int, int)>();
        var step = (goalX, goalY);
        if (!cameFrom.ContainsKey(step))
            return path;
        while (step != (startX, startY))
        {
            path.Insert(0, step);
            step = cameFrom[step];
        }
        return path;
    }
}
