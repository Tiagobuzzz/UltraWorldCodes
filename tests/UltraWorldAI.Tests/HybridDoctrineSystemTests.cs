using System.Collections.Generic;
using UltraWorldAI.Doctrine;
using Xunit;

public class HybridDoctrineSystemTests
{
    [Fact]
    public void CreateDoctrineStoresDoctrine()
    {
        HybridDoctrineSystem.Doctrines.Clear();
        HybridDoctrineSystem.CreateDoctrine(
            "Valor Interno",
            "\u2696",
            "Troca Justa",
            "Filosofia do Sil\u00eancio",
            new List<string> { "Nada vale mais do que a verdade" },
            new List<string> { "Jejum de moedas" },
            "Cultuada");

        Assert.Single(HybridDoctrineSystem.Doctrines);
        var doctrine = HybridDoctrineSystem.Doctrines[0];
        Assert.Equal("Valor Interno", doctrine.Name);
        Assert.Contains("Jejum de moedas", doctrine.Practices);
    }
}
