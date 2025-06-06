using UltraWorldAI;
using Xunit;

public class EmotionSystemLimitTests
{
    [Fact]
    public void SetEmotionRespectsLimit()
    {
        var e = new EmotionSystem { MaxEmotionCount = 2 };
        e.Emotions.Clear();
        e.SetEmotion("a", 0.1f);
        e.SetEmotion("b", 0.2f);
        e.SetEmotion("c", 0.3f);
        Assert.Equal(2, e.Emotions.Count);
        Assert.DoesNotContain("a", e.Emotions.Keys);
    }
}
