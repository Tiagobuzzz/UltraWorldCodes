using UltraWorldAI;
using UltraWorldAI.Thoughts;
using Xunit;

public class LifeNarrativeTests
{
    [Fact]
    public void UpdateNarrativeGeneratesPurpose()
    {
        var engine = new IdeaEngine();
        engine.GeneratedIdeas.Add(new Idea { Title = "Amor", SymbolicPower = 0.6f, EmotionalCharge = 0.6f, IsExpressed = true });
        var narrative = new LifeNarrative(engine);
        narrative.UpdateNarrative();
        Assert.Contains("moldou meu caminho", narrative.SelfNarrative);
        Assert.NotEqual("Desconhecido", narrative.CorePurpose);
    }
}
