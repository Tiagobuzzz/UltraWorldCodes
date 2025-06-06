using UltraWorldAI.Doctrine;
using Xunit;

public class DoctrinalLineageSystemTests
{
    [Fact]
    public void AddNodeStoresLineage()
    {
        DoctrinalLineageSystem.Lineage.Clear();
        DoctrinalLineageSystem.AddNode("Kael", "Troca Justa", "Fundador", "Selena", 1259);
        DoctrinalLineageSystem.AddNode("Selena", "Troca Justa", "Discípula", "Iroren", 1281);

        Assert.Equal(2, DoctrinalLineageSystem.Lineage.Count);
        var successors = DoctrinalLineageSystem.GetSuccessors("Kael");
        Assert.Contains(DoctrinalLineageSystem.Lineage[0], successors);
    }
}

