using UltraWorldAI.Language;
using Xunit;

public class NeologismGeneratorTests
{
    [Fact]
    public void InventWordRespectsLength()
    {
        LanguageCore.Languages.Clear();
        var lang = LanguageCore.CreateLanguage("Neo", new() { "a", "b", "c" }, "SVO", "Alpha");
        var word = NeologismGenerator.InventWord(lang, 3);
        Assert.Equal(3, word.Length);
    }
}
