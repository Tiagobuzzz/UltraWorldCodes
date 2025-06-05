using UltraWorldAI;
using Xunit;

public class IntrospectionSystemTests
{
    [Fact]
    public void ReflectAddsInsight()
    {
        var person = new Person("Insightful");
        person.Mind.Introspection.Reflect(person.Mind);
        Assert.Single(person.Mind.Introspection.RecentInsights);
        Assert.Contains("Percebo que estou", person.Mind.Introspection.GetLastInsight());
    }

    [Fact]
    public void ReflectMentionsStressWhenHigh()
    {
        var person = new Person("Stressed");
        person.Mind.Stress.AddStress(1f);
        person.Mind.Introspection.Reflect(person.Mind);
        var last = person.Mind.Introspection.GetLastInsight();
        Assert.Contains("estresse significativo", last);
    }
}
