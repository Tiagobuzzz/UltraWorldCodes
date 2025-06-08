using UltraWorldAI.Religion;
using Xunit;

public class ProphetEvolutionSystemTests
{
    [Fact]
    public void MartyrdomAndCanonizationProgressesStage()
    {
        var record = ProphetEvolutionSystem.Register("Aro");
        ProphetEvolutionSystem.RecordMartyrdom("Aro");
        ProphetEvolutionSystem.AddReverence("Aro", 0.4f);

        Assert.Equal(ProphetStage.Saint, ProphetEvolutionSystem.GetStage("Aro"));
        Assert.True(record.Reverence >= 0.8f);
    }
}
