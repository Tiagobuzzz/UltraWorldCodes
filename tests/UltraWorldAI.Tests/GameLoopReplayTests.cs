using UltraWorldAI;
using UltraWorldAI.Game;
using Moq;
using Xunit;
using System.Collections.Generic;

public class GameLoopReplayTests
{
    private static IPathfinder CreateMockPathfinder()
    {
        var mock = new Mock<IPathfinder>();
        mock.Setup(p => p.FindPath(It.IsAny<GameMap>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()))
            .Returns(new List<(int, int)> { (0,0) });
        return mock.Object;
    }

    [Fact]
    public void RunReplayCapturesFrames()
    {
        var loop = new GameLoop(2, 2, false, false, CreateMockPathfinder());
        loop.AddPerson(new Person("A"),0,0);
        var replay = loop.RunReplay(3);
        Assert.Equal(3, System.Linq.Enumerable.Count(replay.Frames));
    }
}
