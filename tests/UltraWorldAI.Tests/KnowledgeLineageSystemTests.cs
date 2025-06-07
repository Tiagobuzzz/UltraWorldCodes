using System.Collections.Generic;
using UltraWorldAI.Knowledge;
using Xunit;

public class KnowledgeLineageSystemTests
{
    [Fact]
    public void RegisterLineageStoresSchool()
    {
        KnowledgeLineageSystem.Schools.Clear();
        KnowledgeLineageSystem.RegisterLineage(
            "Saren",
            "Luz",
            new List<string> { "Kael" },
            true,
            "Luz interior");

        Assert.Single(KnowledgeLineageSystem.Schools);
    }

    [Fact]
    public void AddRepressionEventIncrementsCounters()
    {
        KnowledgeLineageSystem.Schools.Clear();
        KnowledgeLineageSystem.RegisterLineage("Saren", "Luz", new List<string>(), true, "");
        KnowledgeLineageSystem.AddRepressionEvent("Luz", "caça");
        KnowledgeLineageSystem.AddRepressionEvent("Luz", "guerra");

        var school = KnowledgeLineageSystem.Schools[0];
        Assert.Equal(1, school.Hunts);
        Assert.Equal(1, school.Wars);
    }
}

