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
}
