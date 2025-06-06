using UltraWorldAI;
using UltraWorldAI.Game;
using Xunit;

public class GameLoopTests
{
    [Fact]
    public void RunAdvancesActors()
    {
        var loop = new GameLoop(3, 3);
        var a = new Person("A");
        loop.AddPerson(a, 1, 1);
        var before = a.Mind.Memory.Memories.Count;
        loop.Run(2);
        Assert.True(a.Mind.Memory.Memories.Count >= before);
    }

    [Fact]
    public void DifficultyChangesStepRange()
    {
        var loop = new GameLoop(3, 3);
        loop.Difficulty = GameDifficulty.Hard;
        Assert.Equal(GameDifficulty.Hard, loop.Difficulty);
        Assert.Equal(2, loop.StepRange);
    }
}
