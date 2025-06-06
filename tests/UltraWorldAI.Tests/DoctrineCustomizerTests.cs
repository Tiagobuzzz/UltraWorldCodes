using System.Collections.Generic;
using UltraWorldAI.Religion;
using Xunit;

public class DoctrineCustomizerTests
{
    [Fact]
    public void CustomizeAddsRulesAndChangesMethod()
    {
        var god = new DivineBeing { Name = "Mythos" };
        var doctrine = DoctrineEngine.CreateDoctrine(god);
        DoctrineCustomizer.Customize(doctrine, new List<string>{"Nova Regra"}, "inscrição", true);

        Assert.Contains("Nova Regra", doctrine.SacredRules);
        Assert.Equal("inscrição", doctrine.TransmissionMethod);
        Assert.True(doctrine.IsMutable);
    }
}
