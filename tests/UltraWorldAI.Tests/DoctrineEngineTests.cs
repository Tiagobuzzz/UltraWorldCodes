using UltraWorldAI;
using UltraWorldAI.Religion;
using Xunit;

public class DoctrineEngineTests
{
    [Fact]
    public void CreateDoctrineFromGodSetsTransmissionMethod()
    {
        var god = new DivineBeing { Name = "Apona", Domain = DivineDomain.Memoria };

        var doctrine = DoctrineEngine.CreateDoctrine(god);

        Assert.Equal("tatuagem", doctrine.TransmissionMethod);
        Assert.Contains("Caminho de", doctrine.Title);
    }

    [Fact]
    public void AddHeresyRegistersContradiction()
    {
        var god = new DivineBeing { Name = "Velar" };
        var doctrine = DoctrineEngine.CreateDoctrine(god);

        DoctrineEngine.AddHeresy(doctrine, "Negar o ritual");

        Assert.Contains("Negar o ritual", doctrine.KnownHeresies);
    }
}
