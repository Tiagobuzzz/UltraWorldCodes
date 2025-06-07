using System;
using System.IO;
using UltraWorldAI.DivineWorld;
using Xunit;

public class DivineReactionSystemTests
{
    [Fact]
    public void ReactToSilenceOutputsMessage()
    {
        var original = Console.Out;
        using var writer = new StringWriter();
        Console.SetOut(writer);
        DivineReactionSystem.ReactToSilence("TestCulture");
        Console.SetOut(original);
        Assert.NotEmpty(writer.ToString());
    }
}
