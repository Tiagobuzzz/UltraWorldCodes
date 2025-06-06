using UltraWorldAI.Language;
using Xunit;

public class LanguageEngineTests
{
    [Fact]
    public void LayersTranslateSequentially()
    {
        LanguageEngine.Clear();
        var layer1 = new TranslationLayer();
        layer1.AddRule("hello", "hola");
        var layer2 = new TranslationLayer();
        layer2.AddRule("hola", "bonjour");
        LanguageEngine.AddLayer(layer1);
        LanguageEngine.AddLayer(layer2);

        var result = LanguageEngine.Translate("hello world");
        Assert.Equal("bonjour world", result);
    }
}

