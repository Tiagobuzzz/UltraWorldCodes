using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UltraWorldAI.Economy;
using Xunit;

public class EconomicDiplomacyTests
{
    [Fact]
    public void CrisisReactionOutputsExpectedMessages()
    {
        EconomicCrisisReactionSystem.Profiles.Clear();
        var original = Console.Out;
        using var writer = new StringWriter();
        Console.SetOut(writer);
        EconomicCrisisReactionSystem.RegisterIA("Kael", 0.9, 0.8, 0.7);
        EconomicCrisisReactionSystem.EvaluateCrisis("Kael", true, true, true);
        Console.SetOut(original);
        var output = writer.ToString();
        Assert.Contains("CRISE DE FÉ", output);
        Assert.Contains("protestos", output);
        Assert.Contains("REFORMA ECONÔMICA", output);
    }

    [Fact]
    public void BetrayalRemovesMemberAndAdjustsTrust()
    {
        TradeDiplomacySystem.Treaties.Clear();
        TradeDiplomacySystem.CreateTreaty("Liga", "Livre Comércio", new List<string> { "Aurora", "Umbra" });
        TradeDiplomacySystem.ModifyTrust("Liga", "Umbra", -40);
        TradeDiplomacySystem.Betrayal("Liga", "Umbra");
        var treaty = TradeDiplomacySystem.Treaties.First();
        Assert.DoesNotContain("Umbra", treaty.Members);
        Assert.Equal(35, treaty.TrustLevel);
    }
}
