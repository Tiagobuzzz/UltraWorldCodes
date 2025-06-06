using UltraWorldAI;
using Xunit;

public class SymbolicMindTests
{
    [Fact]
    public void GenerateSymbolCreatesMentalSymbol()
    {
        var person = new Person("Symbolic");
        person.Mind.Emotions.SetEmotion("fear", 0.8f);
        person.Mind.Symbols.GenerateFromEmotion(person.Mind.Emotions);

        Assert.NotEmpty(person.Mind.Symbols.ActiveSymbols);
        Assert.Equal("abismo", person.Mind.Symbols.ActiveSymbols[0].Archetype);
    }

    [Fact]
    public void IntegrateSymbolAddsBelief()
    {
        var person = new Person("Believer");
        person.Mind.Emotions.SetEmotion("fear", 0.8f);
        person.Mind.Symbols.GenerateFromEmotion(person.Mind.Emotions);
        person.Mind.Symbols.IntegrateSymbolicMeaning(person.Mind.DynamicBeliefs);

        Assert.Contains(person.Mind.DynamicBeliefs.Beliefs,
            b => b.Statement.Contains("abismo"));
    }

    [Fact]
    public void ProceduralScriptExportsSymbols()
    {
        var person = new Person("Procedural");
        person.Mind.Emotions.SetEmotion("fear", 0.8f);
        person.Mind.Symbols.GenerateFromEmotion(person.Mind.Emotions);

        string script = person.Mind.Symbols.ToProceduralScript();

        Assert.Contains("SYMBOL ABISMO MEANS DESCONHECIDO;", script);
    }
}
