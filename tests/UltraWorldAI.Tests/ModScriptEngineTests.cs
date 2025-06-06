using UltraWorldAI.ModScripting;
using Xunit;

public class ModScriptEngineTests
{
    private class TestScript : IModScript
    {
        public string Name => "t";
        public bool Ran { get; private set; }
        public void Initialize(ModContext context) { }
        public void Execute(ModContext context) => Ran = true;
    }

    [Fact]
    public void ExecuteAllRunsScripts()
    {
        var context = new ModContext();
        ModScriptEngine.Clear();
        var script = new TestScript();
        ModScriptEngine.Register(script, context);
        ModScriptEngine.ExecuteAll(context);
        Assert.True(script.Ran);
    }
}

