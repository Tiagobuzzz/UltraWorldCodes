using System.Collections.Generic;
using UltraWorldAI.Module15;
using Xunit;

public class AestheticReactionSystemTests
{
    [Fact]
    public void EvaluateReturnsWeightedSum()
    {
        AestheticReactionSystem.Profiles.Clear();
        AestheticReactionSystem.RegisterProfile("Ana", new() { { "Cor", 0.5f } });
        var score = AestheticReactionSystem.Evaluate("Ana", new() { { "Cor", 2f } });
        Assert.Equal(1f, score);
    }
}
