using UltraWorldAI.Language;
using Xunit;

public class DoctrinalLinguisticAlignmentSystemTests
{
    [Fact]
    public void RegisterDoctrineAddsEntry()
    {
        DoctrinalLinguisticAlignmentSystem.Doctrines.Clear();
        DoctrinalLinguisticAlignmentSystem.RegisterDoctrine("Culto", "Irith", "V\u00e9u", false, "Dogma");
        Assert.Single(DoctrinalLinguisticAlignmentSystem.Doctrines);
    }
}
