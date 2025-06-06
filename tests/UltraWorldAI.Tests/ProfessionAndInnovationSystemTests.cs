using UltraWorldAI.Economy;
using Xunit;

public class ProfessionAndInnovationSystemTests
{
    [Fact]
    public void RegisterProfessionAddsEntry()
    {
        ProfessionAndInnovationSystem.Professions.Clear();
        ProfessionAndInnovationSystem.RegisterProfession("Tecel\u00e3o", "Tear", "Tecido");
        Assert.Single(ProfessionAndInnovationSystem.Professions);
        var p = ProfessionAndInnovationSystem.Professions[0];
        Assert.Equal("Tecel\u00e3o", p.Name);
        Assert.Equal("Tear", p.Tool);
        Assert.Equal("Tecido", p.Output);
    }

    [Fact]
    public void RegisterInventionAddsEntry()
    {
        ProfessionAndInnovationSystem.Inventions.Clear();
        ProfessionAndInnovationSystem.RegisterInvention("Moeda Magica", "Aeron", "Dissolve");
        Assert.Single(ProfessionAndInnovationSystem.Inventions);
        var i = ProfessionAndInnovationSystem.Inventions[0];
        Assert.Equal("Moeda Magica", i.Name);
        Assert.Equal("Aeron", i.CreatedBy);
        Assert.Equal("Dissolve", i.Effect);
    }
}
