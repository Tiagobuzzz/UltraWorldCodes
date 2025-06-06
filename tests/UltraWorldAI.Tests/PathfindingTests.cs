using UltraWorldAI.Game;
using UltraWorldAI;
using Xunit;

public class PathfindingTests
{
    [Fact]
    public void FindPathReturnsRouteAroundObstacle()
    {
        var map = new GameMap(3, 2);
        map.SetPassable(1, 0, false);
        var path = Pathfinding.FindPath(map, 0, 0, 2, 0);
        Assert.True(path.Count > 0);
        Assert.DoesNotContain((1,0), path);
    }

    [Fact]
    public void NoPathReturnsEmptyList()
    {
        var map = new GameMap(2, 1);
        map.SetPassable(1, 0, false);
        var path = Pathfinding.FindPath(map, 0, 0, 1, 0);
        Assert.Empty(path);
    }
}
