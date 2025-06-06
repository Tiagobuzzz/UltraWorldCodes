using UltraWorldAI;
using UltraWorldAI.Game;
using System.Collections.Generic;
using Moq;
using Xunit;

public class GameLoopTests
{
    private static IPathfinder CreateMockPathfinder()
    {
        var mock = new Moq.Mock<IPathfinder>();
        mock.Setup(p => p.FindPath(It.IsAny<GameMap>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()))
            .Returns((GameMap m, int sx, int sy, int gx, int gy) => new List<(int, int)> { (gx, gy) });
        return mock.Object;
    }

    [Fact]
    public void RunAdvancesActors()
    {
        var loop = new GameLoop(3, 3, false, false, CreateMockPathfinder());
        var a = new Person("A");
        loop.AddPerson(a, 1, 1);
        var before = a.Mind.Memory.Memories.Count;
        loop.Run(2);
        Assert.True(a.Mind.Memory.Memories.Count >= before);
    }

    [Fact]
    public void DifficultyChangesStepRange()
    {
        var loop = new GameLoop(3, 3, false, false, CreateMockPathfinder());
        loop.Difficulty = GameDifficulty.Hard;
        Assert.Equal(GameDifficulty.Hard, loop.Difficulty);
        Assert.Equal(2, loop.StepRange);
    }

    [Fact]
    public void PersonUpdatedEventIsRaised()
    {
        var loop = new GameLoop(3, 3, false, false, CreateMockPathfinder());
        var p = new Person("Evt");
        loop.AddPerson(p, 0, 0);
        bool fired = false;
        loop.PersonUpdated += _ => fired = true;
        loop.Run(1);
        Assert.True(fired);
    }

    [Fact]
    public void PausePreventsStepExecution()
    {
        var loop = new GameLoop(3, 3, false, false, CreateMockPathfinder());
        var p = new Person("Idle");
        loop.AddPerson(p, 0, 0);
        loop.Pause();
        loop.Run(1);
        Assert.Empty(p.Mind.Memory.Memories);
    }
}
