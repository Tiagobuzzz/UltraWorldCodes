using UltraWorldAI;
using System.Collections.Generic;
using Xunit;

public class InteractionSystemTests
{
    [Fact]
    public void BranchingDialogueStopsAfterMax()
    {
        var a = new Person("A");
        var b = new Person("B");
        var branches = new Dictionary<int, List<string>>
        {
            [0] = new List<string>{"hi"}
        };
        InteractionSystem.BranchingDialogue(a, b, branches, (_, __) => 0, 3);
        Assert.Equal(3, b.Mind.Memory.Memories.Count);
    }
}
