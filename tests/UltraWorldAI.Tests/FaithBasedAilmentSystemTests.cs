using System;
using System.IO;
using UltraWorldAI.Health;
using Xunit;

public class FaithBasedAilmentSystemTests
{
    [Fact]
    public void TriggerDiseaseAddsDisease()
    {
        FaithBasedAilmentSystem.ActiveDiseases.Clear();
        FaithBasedAilmentSystem.TriggerDisease("Sarith", "Som da flauta atrai demonios", "Surdez parcial", 0.3f);
        Assert.Contains(FaithBasedAilmentSystem.ActiveDiseases, d => d.Culture == "Sarith" && d.TriggerBelief == "Som da flauta atrai demonios");
    }

    [Fact]
    public void ApplyCureOutputsWhenCureExists()
    {
        FaithBasedAilmentSystem.ActiveCures.Clear();
        FaithBasedAilmentSystem.RegisterCure("Sarith", "Beijo na testa", "Remove delirio");
        var original = Console.Out;
        using var writer = new StringWriter();
        Console.SetOut(writer);
        FaithBasedAilmentSystem.ApplyCure("Thalor", "Beijo na testa", "Sarith");
        Console.SetOut(original);
        Assert.Contains("usou a cura", writer.ToString());
    }
}
