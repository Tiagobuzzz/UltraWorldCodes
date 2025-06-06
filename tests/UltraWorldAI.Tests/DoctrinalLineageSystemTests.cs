using UltraWorldAI.Education;
using System.Linq;
using Xunit;

public class DoctrinalLineageSystemTests
{
    [Fact]
    public void AddLineageStoresSuccessor()
    {
        DoctrinalLineageSystem.Lineages.Clear();
        DoctrinalLineageSystem.AddLineage("Mestre", "Aluno", "heresia leve");
        Assert.Single(DoctrinalLineageSystem.GetSuccessors("Mestre"));
    }
}
