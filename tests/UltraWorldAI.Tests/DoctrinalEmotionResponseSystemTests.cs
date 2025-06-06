using UltraWorldAI.Doctrine;
using Xunit;

public class DoctrinalEmotionResponseSystemTests
{
    [Fact]
    public void RegisterIAStoresResponse()
    {
        DoctrinalEmotionResponseSystem.Responses.Clear();
        DoctrinalEmotionResponseSystem.RegisterIA("Selena", "Caminho", 0.8);
        Assert.Single(DoctrinalEmotionResponseSystem.Responses);
    }

    [Fact]
    public void ReactToTraumaUpdatesEmotion()
    {
        DoctrinalEmotionResponseSystem.Responses.Clear();
        DoctrinalEmotionResponseSystem.RegisterIA("Selena", "Caminho", 1.0);
        DoctrinalEmotionResponseSystem.ReactToTrauma("Selena", "Profana\u00e7\u00e3o");
        var r = DoctrinalEmotionResponseSystem.Responses[0];
        Assert.True(r.Anger > 0);
        Assert.True(r.Fanaticism > 0);
    }
}
