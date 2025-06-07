using System.Collections.Generic;
using UltraWorldAI.Knowledge;
using Xunit;

public class SecretKnowledgeNetworkSystemTests
{
    [Fact]
    public void CreateCellAddsCell()
    {
        SecretKnowledgeNetworkSystem.Cells.Clear();
        SecretKnowledgeNetworkSystem.CreateCell("C\u00edrculo", "Cidade", new List<string> { "Magia" });
        Assert.Single(SecretKnowledgeNetworkSystem.Cells);
    }
}
