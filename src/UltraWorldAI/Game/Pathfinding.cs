using System.Collections.Generic;

namespace UltraWorldAI.Game;

public static class Pathfinding
{
    private record Node(int X, int Y, Node? Parent);

    public static List<(int x, int y)> FindPath(GameMap map, int startX, int startY, int endX, int endY)
    {
        var visited = new bool[map.Width, map.Height];
        var queue = new Queue<Node>();
        queue.Enqueue(new Node(startX, startY, null));
        visited[startX, startY] = true;

        int[] dirs = { -1, 0, 1 };
        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
            if (node.X == endX && node.Y == endY)
                return Reconstruct(node);

            foreach (var dx in dirs)
            foreach (var dy in dirs)
            {
                if (dx == 0 && dy == 0) continue;
                int nx = node.X + dx;
                int ny = node.Y + dy;
                if (!map.IsPassable(nx, ny)) continue;
                if (visited[nx, ny]) continue;
                visited[nx, ny] = true;
                queue.Enqueue(new Node(nx, ny, node));
            }
        }
        return new();
    }

    private static List<(int x, int y)> Reconstruct(Node node)
    {
        var path = new List<(int, int)>();
        while (node.Parent != null)
        {
            path.Insert(0, (node.X, node.Y));
            node = node.Parent;
        }
        return path;
    }
}

