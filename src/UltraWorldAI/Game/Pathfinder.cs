using System;
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
        var open = new PriorityQueue<(int x, int y), int>();
        var cameFrom = new Dictionary<(int x, int y), (int x, int y)>();
        var costSoFar = new Dictionary<(int x, int y), int>();

        open.Enqueue((startX, startY), 0);
        costSoFar[(startX, startY)] = 0;
        cameFrom[(startX, startY)] = (startX, startY);

        while (open.Count > 0)
        {
            var current = open.Dequeue();
            if (current == (goalX, goalY))
                break;

            foreach (var dir in Directions)
            {
                int nx = current.x + dir.x;
                int ny = current.y + dir.y;
                if (nx < 0 || ny < 0 || nx >= map.Width || ny >= map.Height)
                    continue;
                if (map.IsObstacleAt(nx, ny))
                    continue;

                int newCost = costSoFar[current] + 1;
                if (!costSoFar.TryGetValue((nx, ny), out var prev) || newCost < prev)
                {
                    costSoFar[(nx, ny)] = newCost;
                    int priority = newCost + Heuristic(nx, ny, goalX, goalY);
                    open.Enqueue((nx, ny), priority);
                    cameFrom[(nx, ny)] = current;
                }
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

    private static int Heuristic(int x, int y, int gx, int gy) => Math.Abs(x - gx) + Math.Abs(y - gy);
}
