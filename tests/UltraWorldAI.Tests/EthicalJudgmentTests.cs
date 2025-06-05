using System.Collections.Generic;
using UltraWorldAI;
using UltraWorldAI.Thoughts;
using Xunit;

public class EthicalJudgmentTests
{
    [Fact]
    public void JudgeActionReturnsEthicalForSupportedIdeas()
    {
        var engine = new IdeaEngine();
        engine.GeneratedIdeas.Add(new Idea { Title = "A", EmotionalCharge = 0.6f, SymbolicPower = 0.7f });
        var judge = new EthicalJudgment(engine);
        var result = judge.JudgeAction("acao", new List<string> { "A" });
        Assert.Contains("ÉTICA", result);
    }

    [Fact]
    public void JudgeActionReturnsImoralForOpposingIdeas()
    {
        var engine = new IdeaEngine();
        engine.GeneratedIdeas.Add(new Idea { Title = "X", EmotionalCharge = 0.1f, SymbolicPower = 0.9f });
        var judge = new EthicalJudgment(engine);
        var result = judge.JudgeAction("acao", new List<string> { "X" });
        Assert.Contains("IMORAL", result);
    }
}
