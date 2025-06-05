using System.Collections.Generic;
using UltraWorldAI.Religion;
using Xunit;

public class TechCultSystemTests
{
    [Fact]
    public void CreateCultAddsCult()
    {
        TechCultSystem.AllCults.Clear();
        var cult = TechCultSystem.CreateCult("TecZ", "Ana", "oração", new List<string>{"crença"}, false);

        Assert.Single(TechCultSystem.AllCults);
        Assert.Equal("Culto de TecZ", cult.Name);
    }
}
