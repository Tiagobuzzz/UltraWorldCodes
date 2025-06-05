using System.Collections.Generic;
using UltraWorldAI;
using Xunit;

public class CulturalReformationTests
{
    [Fact]
    public void IntegratesExpressedIdeas()
    {
        var mind = new Person("Reformador").Mind;
        mind.IdeaEngine.GeneratedIdeas.Add(new Idea { Title = "Harmonia", IsExpressed = true, SymbolicPower = 0.7f });
        var culture = new Culture();

        CulturalReformation.AttemptReformation(mind, culture);

        Assert.Contains("Harmonia", culture.CoreValues);
    }

    [Fact]
    public void TabooIdeasIncreaseStress()
    {
        var mind = new Person("Tabu").Mind;
        mind.IdeaEngine.GeneratedIdeas.Add(new Idea { Title = "Segredo Proibido", IsExpressed = true, SymbolicPower = 0.7f });
        var culture = new Culture { Taboos = new List<string> { "Proibido" } };

        CulturalReformation.AttemptReformation(mind, culture);

        Assert.True(mind.Stress.CurrentStressLevel > AIConfig.MinStress);
    }
}
