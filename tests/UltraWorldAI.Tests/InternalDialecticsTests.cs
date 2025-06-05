using System.Linq;
using UltraWorldAI;
using UltraWorldAI.Thoughts;
using Xunit;

public class InternalDialecticsTests
{
    [Fact]
    public void EngageDebateCreatesSynthesisWhenBalanced()
    {
        var engine = new IdeaEngine();
        engine.GeneratedIdeas.Add(new Idea { Title = "A", EmotionalCharge = 0.5f, SymbolicPower = 0.5f });
        engine.GeneratedIdeas.Add(new Idea { Title = "B", EmotionalCharge = 0.6f, SymbolicPower = 0.4f });
        var dialectics = new InternalDialectics(engine);

        var result = dialectics.EngageDebate("A", "B");

        Assert.Contains("Síntese", result);
        Assert.Equal(3, engine.GeneratedIdeas.Count);
    }

    [Fact]
    public void EngageDebateBoostsWinnerWhenPowerDiffers()
    {
        var engine = new IdeaEngine();
        engine.GeneratedIdeas.Add(new Idea { Title = "X", EmotionalCharge = 0.9f, SymbolicPower = 0.8f });
        engine.GeneratedIdeas.Add(new Idea { Title = "Y", EmotionalCharge = 0.2f, SymbolicPower = 0.1f });
        var dialectics = new InternalDialectics(engine);

        var result = dialectics.EngageDebate("X", "Y");

        Assert.Contains("Ideia vencedora", result);
        var winner = engine.GeneratedIdeas.First(i => i.Title == "X");
        Assert.True(winner.SymbolicPower > 0.8f);
    }
}
