using UltraWorldAI;
using Xunit;

public class IntuitionSystemTests
{
    [Fact]
    public void GenerateInsightCreatesEntry()
    {
        var person = new Person("Tester");
        person.Mind.BrainMap.Connect("happiness", "nature", 0.5f);
        person.Mind.Emotions.SetEmotion("happiness", 0.9f);
        person.Mind.Intuition.GenerateInsight(person.Mind);
        Assert.Single(person.Mind.Intuition.Insights);
        Assert.Contains(person.Mind.Memory.Memories, m => m.Summary.Contains("Insight:"));
    }

    [Fact]
    public void ReinforceInsightRaisesConfidence()
    {
        var person = new Person("Tester");
        person.Mind.BrainMap.Connect("fear", "noite", 0.5f);
        person.Mind.Emotions.SetEmotion("fear", 0.9f);
        person.Mind.Intuition.GenerateInsight(person.Mind);
        var statement = person.Mind.Intuition.Insights[0].Statement;
        person.Mind.Intuition.ReinforceInsight(statement, 0.6f);
        var core = person.Mind.Intuition.GetCoreBeliefs();
        Assert.Contains(person.Mind.Intuition.Insights[0], core);
    }

    [Fact]
    public void NoInsightWhenNoAssociations()
    {
        var person = new Person("Blank");
        person.Mind.Emotions.SetEmotion("fear", 0.8f);
        person.Mind.Intuition.GenerateInsight(person.Mind);
        Assert.Empty(person.Mind.Intuition.Insights);
    }
}
