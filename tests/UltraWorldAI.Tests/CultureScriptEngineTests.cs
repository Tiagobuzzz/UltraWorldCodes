using System.Collections.Generic;
using UltraWorldAI;
using Xunit;

public class CultureScriptEngineTests
{
    private class AddValueScript : ICultureScript
    {
        public string Name => "add";
        public void Run(Culture culture) => culture.CoreValues.Add("custom");
    }

    [Fact]
    public void ExecuteAddsValues()
    {
        CultureScriptEngine.Clear();
        CultureScriptEngine.Register(new AddValueScript());
        var system = new CultureSystem();
        var culture = system.CreateCultureFromIdea("Idea", new List<string> { "v1" });
        Assert.Contains("custom", culture.CoreValues);
    }
}
