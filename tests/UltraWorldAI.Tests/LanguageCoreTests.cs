using UltraWorldAI.Language;
using Xunit;

public class LanguageCoreTests
{
    [Fact]
    public void CreateLanguageAddsToList()
    {
        LanguageCore.Languages.Clear();
        var lang = LanguageCore.CreateLanguage("Test", new() { "a" }, "SVO", "Alpha");
        Assert.Contains(lang, LanguageCore.Languages);
    }

    [Fact]
    public void AddRootWordStoresWord()
    {
        LanguageCore.Languages.Clear();
        var lang = LanguageCore.CreateLanguage("Test", new() { "a" }, "SVO", "Alpha");
        LanguageCore.AddRootWord(lang, "abc");
        Assert.Contains("abc", lang.RootWords);
    }
}
