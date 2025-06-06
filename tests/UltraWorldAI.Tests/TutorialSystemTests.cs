using System.Collections.Generic;
using UltraWorldAI.Interface;
using Xunit;

public class TutorialSystemTests
{
    [Fact]
    public void NextStepReturnsInOrder()
    {
        var tutorial = new TutorialSystem(new[] { "step1", "step2" });
        Assert.Equal("step1", tutorial.NextStep());
        Assert.Equal("step2", tutorial.NextStep());
        Assert.Null(tutorial.NextStep());
    }
}
