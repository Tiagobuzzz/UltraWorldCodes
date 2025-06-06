using System.Collections.Generic;
using UltraWorldAI.Robotics;
using Xunit;

public class ModularRobotBuilderTests
{
    [Fact]
    public void CreateBuildsRobotWithModules()
    {
        var r = ModularRobotBuilder.Create("R1", new List<string>{"arm"});
        Assert.Contains("arm", r.Modules);
    }
}
