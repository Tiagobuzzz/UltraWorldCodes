using System.Collections.Generic;
using UltraWorldAI.Knowledge;
using Xunit;

public class KnowledgeEvolutionSystemTests
{
    [Fact]
    public void RegisterKnowledgeAddsItem()
    {
        KnowledgeEvolutionSystem.KnowledgeBase.Clear();
        KnowledgeEvolutionSystem.RegisterKnowledge("Rotac\u00e3o", "Contestado", "Observa\u00e7\u00e3o", new List<string> { "Grupo" });
        Assert.Single(KnowledgeEvolutionSystem.KnowledgeBase);
    }
}
