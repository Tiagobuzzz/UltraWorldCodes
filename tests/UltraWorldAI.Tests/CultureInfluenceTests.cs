using System.Collections.Generic;
using UltraWorldAI;
using Xunit;

public class CultureInfluenceTests
{
    [Fact]
    public void ApplyCultureToMindGeneratesIdeas()
    {
        var culture = new Culture
        {
            CoreValues = new List<string> { "Respeito" },
            Taboos = new List<string> { "Mentir" },
            Traditions = new List<Tradition>
            {
                new() { Name = "Saudacao" , Rituals = new List<RitualInstance>() }
            }
        };
        var person = new Person("CulturalMind");

        CultureInfluence.ApplyCultureToMind(culture, person.Mind);

        Assert.Contains(person.Mind.IdeaEngine.GeneratedIdeas, i => i.Title.Contains("Valor cultural: Respeito"));
        Assert.Contains(person.Mind.IdeaEngine.GeneratedIdeas, i => i.Title.Contains("Tabu presente: Mentir"));
        Assert.Contains(person.Mind.IdeaEngine.GeneratedIdeas, i => i.Title.Contains("Ritual observado: Saudacao"));
    }

    [Fact]
    public void UpdateCultureFromMindAddsIdeasAndRitual()
    {
        var culture = new Culture();
        var mind = new Person("Pioneiro").Mind;
        mind.IdeaEngine.GeneratedIdeas.AddRange(new[]
        {
            new Idea { Title = "Visao", IsExpressed = true, SymbolicPower = 0.8f },
            new Idea { Title = "Canto", IsExpressed = true, SymbolicPower = 0.9f },
            new Idea { Title = "Eco", IsExpressed = true, SymbolicPower = 0.8f },
            new Idea { Title = "Chama", IsExpressed = true, SymbolicPower = 0.85f }
        });

        CultureInfluence.UpdateCultureFromMind(mind, culture);

        Assert.Contains("Visao", culture.AssociatedIdeas);
        Assert.Contains(culture.CoreValues, v => v.Contains("Visao"));
        Assert.Contains(culture.Traditions, t => t.Name == "Ritual da Palavra Viva");
    }
}
