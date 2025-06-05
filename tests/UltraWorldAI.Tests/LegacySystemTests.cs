using System.Linq;
using UltraWorldAI;
using Xunit;

public class LegacySystemTests
{
    [Fact]
    public void DescendantInheritsTraitsBeliefsAndMemories()
    {
        var parent = new Person("Parent");
        parent.Mind.Beliefs.UpdateBelief("Visao: legado", 0.9f);
        parent.AddExperience("evento marcante", 0.8f, 0.9f);
        parent.Mind.Personality.SetTrait("Abertura", 0.9f);

        var child = Person.CreateDescendant(parent, "Child");

        Assert.Contains(parent.Mind.Memory.Memories[0].Summary, child.Mind.Memory.Memories[0].Summary);
        Assert.Contains("Visao: legado", child.Mind.Beliefs.Beliefs.Keys);
        Assert.True(child.Mind.Personality.GetTrait("Abertura") > 0.7f);
    }
}
