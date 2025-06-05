using System.Collections.Generic;
using UltraWorldAI;
using Xunit;

public class IdeaEngineTests
{
    [Fact]
    public void GenerateIdeaStoresIdea()
    {
        var engine = new IdeaEngine();
        var emotions = new EmotionSystem();
        engine.GenerateIdea("insp", new List<string>(), emotions);
        Assert.Single(engine.GeneratedIdeas);
        Assert.Equal("insp", engine.GeneratedIdeas[0].Title);
    }

    [Fact]
    public void LinkIdeasCreatesBrainwire()
    {
        var engine = new IdeaEngine();
        engine.LinkIdeas("a", "b");
        Assert.Single(engine.BrainConnections);
        Assert.Equal("a", engine.BrainConnections[0].IdeaA);
    }

    [Fact]
    public void ExpressIdeaIncreasesInfluence()
    {
        var person = new Person("Thinker");
        var engine = new IdeaEngine();
        engine.GenerateIdea("dream", new List<string>(), person.Mind.Emotions);
        engine.ExpressIdea("dream", person.Mind);
        var idea = engine.GeneratedIdeas[0];
        Assert.True(idea.IsExpressed);
        Assert.True(idea.InfluenceOnWorld > 0f);
    }
}
