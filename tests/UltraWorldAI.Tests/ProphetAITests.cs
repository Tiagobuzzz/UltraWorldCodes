using System;
using System.IO;
using UltraWorldAI.Religion;
using Xunit;

public class ProphetAITests
{
    [Fact]
    public void InterpretDivineWillOutputsVision()
    {
        var prophet = new ProphetAI
        {
            Name = "Lior",
            Culture = "Sarith",
            FaithLevel = 1f,
            MadnessLevel = 0f
        };

        var original = Console.Out;
        using var writer = new StringWriter();
        Console.SetOut(writer);
        prophet.InterpretDivineWill();
        Console.SetOut(original);
        Assert.Contains("Lior", writer.ToString());
    }
}
