using System.Collections.Generic;
using UltraWorldAI.Religion;
using Xunit;

public class CultSplitTests
{
    [Fact]
    public void CreateCultFromDoctrineRegistersCult()
    {
        var doctrine = new Doctrine
        {
            Title = "Origem",
            SacredRules = new List<string> { "Seguir a luz", "proibido mentir" },
            IsMutable = false
        };

        var cult = CultSplit.CreateCultFromDoctrine(doctrine, "Ana", "discordância");

        Assert.Contains(cult, CultSplit.AllCults);
        Assert.DoesNotContain(cult.NewDogmas, d => d.Contains("proibido"));
        Assert.Contains(doctrine.KnownHeresies, h => h.Contains("Ana"));
    }

    [Fact]
    public void PersecuteCultMarksCult()
    {
        var cult = new Cult { Name = "Test", OriginDoctrine = "Base" };

        CultSplit.PersecuteCult(cult);

        Assert.True(cult.IsPersecuted);
        Assert.Contains(cult.NewDogmas, d => d.Contains("Sofremos"));
    }
}
