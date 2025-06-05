using UltraWorldAI;
using Xunit;

public class SymbolicExpressionSystemTests
{
    [Fact]
    public void GenerateSymbolAddsEntryAndMemory()
    {
        var person = new Person("Creator");
        var system = new SymbolicExpressionSystem();
        system.GenerateSymbolFromExperience(person);

        Assert.NotEmpty(system.Symbols);
        Assert.Contains(person.Mind.Memory.Memories, m => m.Summary.Contains("Criou símbolo"));
    }

    [Fact]
    public void LexiconReflectsStoredSymbols()
    {
        var person = new Person("Creator");
        var system = new SymbolicExpressionSystem();
        system.GenerateSymbolFromExperience(person);

        var lexicon = system.GetSymbolicLexicon();
        Assert.Contains(system.Symbols[0].Motif, lexicon[0]);
    }
}
