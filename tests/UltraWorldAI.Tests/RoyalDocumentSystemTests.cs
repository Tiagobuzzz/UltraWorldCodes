using UltraWorldAI.Politics;
using Xunit;

public class RoyalDocumentSystemTests
{
    [Fact]
    public void IssueDocumentAddsRecord()
    {
        RoyalDocumentSystem.Documents.Clear();
        RoyalDocumentSystem.IssueDocument("Edito 1", "Kael", "Edito", "Conteudo");
        Assert.Single(RoyalDocumentSystem.Documents);
    }

    [Fact]
    public void ForgedDocumentFlagIsSet()
    {
        RoyalDocumentSystem.Documents.Clear();
        RoyalDocumentSystem.IssueDocument("Falso", "Aeron", "Edito", "Texto", true);
        Assert.True(RoyalDocumentSystem.Documents[0].IsForged);
    }
}
