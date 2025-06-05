using System.Collections.Generic;
using UltraWorldAI;
using UltraWorldAI.Thoughts;
using Xunit;

public class PhilosophicalIntegrityTests
{
    [Fact]
    public void EvaluateConsistencyReturnsLowerScoreForConflictingIdeas()
    {
        var engine = new IdeaEngine();
        engine.GeneratedIdeas.Add(new Idea { Title = "a", SymbolicPower = 0.1f, EmotionalCharge = 0.2f });
        engine.GeneratedIdeas.Add(new Idea { Title = "b", SymbolicPower = 0.9f, EmotionalCharge = -0.5f });
        engine.BrainConnections.Add(new Brainwire { IdeaA = "a", IdeaB = "b", Strength = 0.2f });

        var integrity = new PhilosophicalIntegrity(engine);
        var score = integrity.EvaluateConsistency();

        Assert.True(score < 1f);
        Assert.Equal(2, integrity.GetContradictoryIdeas().Count);
    }

    [Fact]
    public void EvaluateConsistencyZeroWhenNoConnections()
    {
        var integrity = new PhilosophicalIntegrity(new IdeaEngine());
        var score = integrity.EvaluateConsistency();
        Assert.Equal(0f, score);
    }
}
