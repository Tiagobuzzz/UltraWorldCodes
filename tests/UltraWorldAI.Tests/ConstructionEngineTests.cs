using UltraWorldAI;
using UltraWorldAI.Territory;
using Xunit;

public class ConstructionEngineTests
{
    [Fact]
    public void BuildStructureCreatesEntryAndSanctifiesWhenEmotional()
    {
        var builder = new Person("Construtor");
        builder.Mind.Emotions.SetEmotion("happiness", 0.9f);

        ConstructionEngine.BuildStructure(builder.Mind, builder.Location, "fé na comunidade");

        Assert.Single(ConstructionEngine.BuiltStructures);
        var structure = ConstructionEngine.BuiltStructures[0];
        Assert.Equal("Templo", structure.Type);
        Assert.True(SacredSpace.IsSacred(builder.Location.RegionName));
    }
}

