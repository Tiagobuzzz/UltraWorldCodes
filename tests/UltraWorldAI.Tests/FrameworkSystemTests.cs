using UltraWorldAI;
using Xunit;

public class FrameworkSystemTests
{
    private class TestModule : IFrameworkModule
    {
        public string Name => "Test";
        public bool Initialized { get; private set; }
        public bool Updated { get; private set; }
        public void Initialize(Person person) => Initialized = true;
        public void Update(Person person) => Updated = true;
    }

    [Fact]
    public void AddModuleInitializesIt()
    {
        var person = new Person("Tester");
        var module = new TestModule();
        person.Mind.Framework.AddModule(module);
        Assert.True(module.Initialized);
    }

    [Fact]
    public void UpdateCallsModuleUpdate()
    {
        var person = new Person("Tester");
        var module = new TestModule();
        person.Mind.Framework.AddModule(module);
        person.Mind.Framework.Update();
        Assert.True(module.Updated);
    }
}
