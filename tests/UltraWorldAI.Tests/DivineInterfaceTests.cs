using System;
using System.IO;
using UltraWorldAI.DivineWorld;
using UltraWorldAI.Interface;
using Xunit;

public class DivineInterfaceTests
{
    [Fact]
    public void ConfirmActionInvokesDivineWillSystem()
    {
        DivineWillSystem.Interventions.Clear();
        var di = new DivineInterface
        {
            SelectedActionType = "Milagre",
            Target = "Povoado",
            Description = "Chuva de cura"
        };

        var original = Console.Out;
        using var writer = new StringWriter();
        Console.SetOut(writer);
        di.ConfirmAction();
        Console.SetOut(original);

        Assert.Single(DivineWillSystem.Interventions);
        Assert.Contains("A\u00e7\u00e3o divina enviada", writer.ToString());
    }
}
