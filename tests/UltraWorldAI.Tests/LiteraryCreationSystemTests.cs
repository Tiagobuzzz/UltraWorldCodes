using UltraWorldAI.Module15;
using Xunit;

public class LiteraryCreationSystemTests
{
    [Fact]
    public void WriteAddsWork()
    {
        LiteraryCreationSystem.Works.Clear();
        LiteraryCreationSystem.Write("Ana", "Poema", "Irônico", "Trecho");
        Assert.Contains(LiteraryCreationSystem.Works, w => w.Form == "Poema" && w.Author == "Ana");
    }
}
