using UltraWorldAI.Knowledge;
using Xunit;

public class ArchivistFervorSystemTests
{
    [Fact]
    public void GuardDocumentAddsRecord()
    {
        ArchivistFervorSystem.Records.Clear();
        ArchivistFervorSystem.GuardDocument("Lena", "Pergaminho", "Mártir");
        Assert.Single(ArchivistFervorSystem.Records);
    }
}
