using UltraWorldAI.Game;
using Xunit;

public class PathfinderTests
{
    [Fact]
    public void FindsPathAroundObstacle()
    {
        var map = new GameMap(5,5);
        map.SetObstacle(2,1,true);
        map.SetObstacle(2,2,true);
        map.SetObstacle(2,3,true);
        var path = Pathfinder.FindPath(map, 1,2,3,2);
        Assert.True(path.Count > 0);
        Assert.Equal((3,2), path[^1]);
    }
}
