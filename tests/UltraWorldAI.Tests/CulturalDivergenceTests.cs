using System.Collections.Generic;
using UltraWorldAI;
using Xunit;

public class CulturalDivergenceTests
{
    [Fact]
    public void CheckForRuptureDetectsConflicts()
    {
        var person = new Person("RuptureTest");
        var mind = person.Mind;
        mind.IdeaEngine.GeneratedIdeas.AddRange(new[]
        {
            new Idea { Title = "Tabu1 secreto", SymbolicPower = 0.8f },
            new Idea { Title = "Outro Tabu1", SymbolicPower = 0.9f }
        });
        var culture = new Culture
        {
            Name = "Base",
            Taboos = new List<string> { "Tabu1" }
        };

        Assert.True(CulturalDivergence.CheckForRupture(mind, culture));
    }

    [Fact]
    public void CreateNewCultureFromRuptureCopiesData()
    {
        var person = new Person("Fragmento");
        var mind = person.Mind;
        mind.IdeaEngine.GeneratedIdeas.Add(new Idea { Title = "Ideia Expressa", IsExpressed = true, SymbolicPower = 0.6f });
        var parent = new Culture { Name = "Original" };
        var child = CulturalDivergence.CreateNewCultureFromRupture(mind, parent);

        Assert.Contains("Original", child.Name);
        Assert.Equal(CalendarType.Emocional, child.CalendarType);
        Assert.Contains(child.CoreValues, v => v.Contains("Ideia Expressa"));
    }
}
